using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace FillTheCity
{
    public class Customer : MonoBehaviour
    {
        private enum CustomerState { Spawn, Wait, Left }
        private CustomerState state = CustomerState.Spawn;

        [SerializeField] private Transform firstPos, midP, endPos;

        [SerializeField] private int minSpawn, maxSpawn;

        [SerializeField] private int timeToWait = 5;
        [SerializeField] private Transform costumerModel;
        [SerializeField] private Transform customerCanvas;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private OrderType[] orderTypes;

        private int orderCount;
        private bool canAction;
        private bool canWait;
        private bool canSpawn;
        private int timeToSpawn;
        private bool _canRandom;
        private int _random;
        private List<RectTransform> orderCanvasList = new List<RectTransform>();

        private float _currentTime;

        #region Unity Methods

        private void Start()
        {
            _canRandom = true;
            canSpawn = true;
        }

        private void Update()
        {
            CheckState();
        }

        #endregion

        #region Custom Methods

        private void Movement()
        {
            canAction = false;
            float moveSpeed = 2;
            costumerModel.transform.DOLocalMove(midP.position, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
                 {
                     state = CustomerState.Wait;
                     canAction = true;
                     _canRandom = true;
                     canSpawn = true;
                 });
        }

        private void Leave()
        {
            canAction = false;
            for (int i = 0; i < orderCanvasList.Count; i++)
            {
                Destroy(orderCanvasList[i].gameObject);
            }
            orderCanvasList.Clear();

            float moveSpeed = 2;
            costumerModel.transform.DOLocalMove(endPos.position, moveSpeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                costumerModel.transform.position = firstPos.position;
                state = CustomerState.Spawn;
                canAction = true;
                _canRandom = true;
                canSpawn = true;
                //  orderCanvasList.Clear();
            });
        }

        private void ordering()
        {
            canAction = false;
            var orderNum = Random.Range(1, orderTypes.Length);
            for (int i = 0; i < orderNum; i++)
            {
                var orderAmount = orderTypes[i].Amount();
                var orderCanvas = Instantiate(orderTypes[i].OrderIMG,
                    costumerModel.transform.position, Quaternion.Euler(0, -90, 0), customerCanvas);
                orderCanvasList.Add(orderCanvas);
                orderCanvas.GetComponentInChildren<TextMeshProUGUI>().text = orderAmount.ToString();
            }
            print("order");
        }


        private void GiveMoney()
        {

        }

        private int GetRandom(int min, int max)
        {
            var random = Random.Range(min, max);
            _canRandom = false;
            return random;
        }


        private void Timer(float counter, ref bool reach)
        {
            if (!canSpawn) return;
            _currentTime += Time.deltaTime;
            if (_currentTime >= counter)
            {
                _currentTime = 0;
                reach = true;
                canSpawn = false;
            }
        }

        private void CheckState()
        {
            switch (state)
            {
                case CustomerState.Spawn:
                    if (_canRandom)
                        _random = GetRandom(minSpawn, maxSpawn);
                    Timer(_random, ref canAction);
                    if (canAction)
                        Movement();
                    break;
                case CustomerState.Wait:
                    if (_canRandom)
                        _random = GetRandom(minSpawn, maxSpawn);
                    //print("Random wait: "+_random);
                    Timer(_random, ref canAction);
                    if (canAction && canSpawn)
                        ordering();
                    if (canAction)
                        state = CustomerState.Left;
                    break;
                case CustomerState.Left:
                    if (canAction)
                        Leave();
                    break;
            }
        }


        #endregion







        [System.Serializable]
        public class OrderType
        {
            public string Name;
            public RectTransform OrderIMG;

            public int Amount()
            {
                int min = 1; int max = 10;
                var orderAmount = Random.Range(min, max);
                return orderAmount;
            }
        }
    }

}
