using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        [SerializeField] private RectTransform orderContainer;

        private int orderCount;
        private bool canAction;
        private bool canWait;
        private bool canSpawn;
        private int timeToSpawn;
        private bool _canRandom;
        private int _random;

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
                 });


        }

        private void ordering()
        {
            canAction = false;
            var orderNum = Random.Range(1, orderTypes.Length);
            print(orderNum);
            for (int i = 0; i < orderNum; i++)
            {
                var orderAnount=orderTypes[i].Amount();
                Instantiate(orderContainer, costumerModel.transform.position,Quaternion.Euler(0,-90,0), customerCanvas);
            }

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


        private void Timer(float counter)
        {
            if (!canSpawn) return;
            _currentTime += Time.deltaTime;
            if (_currentTime >= counter)
            {
                canAction = true;
                _canRandom = true;
                _currentTime = 0;
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
                    Timer(_random);
                    if (canAction)
                        Movement();
                    break;
                case CustomerState.Wait:
                    if (_canRandom)
                        _random = GetRandom(minSpawn, maxSpawn);
                    Timer(_random);
                    if (canAction)
                        ordering();

                    break;
                case CustomerState.Left:
                    break;
            }
        }


        #endregion







        [System.Serializable]
        public class OrderType
        {
            public string Name;
            public Sprite OrderIMG;

            public int Amount()
            {
                int min = 0; int max = 10;
                var orderAmount = Random.Range(min, max);
                return orderAmount;
            }
        }
    }

}
