using System.Collections;
using UnityEngine;

namespace CatchTheGiant
{
    public class CGPlayerMovement : MonoBehaviour
    {
        public static CGPlayerMovement Instance;
        private enum types { Player, AI }
        [SerializeField] private types type = types.Player;
        [SerializeField] private float VSpeed = 5f;
//        [SerializeField] private float HSpeed = 4f;
        [SerializeField] private float maxHorizontal;
        private float FirstPos;
        float deltaSwip;
        public bool canMove, canControl;
        private Vector3 firstpos;

        private void OnEnable()
        {
            CGGameManager.LevelWin += levelWin;
            CGGameManager.LevelLose += levelLose;

        }

        private void OnDisable()
        {
            CGGameManager.LevelWin -= levelWin;
            CGGameManager.LevelLose += levelLose;
        }

        private void Awake()
        {
            Instance = this;
        }


        // Start is called before the first frame update
        void Start()
        {
            firstpos = transform.position;

            if (type == types.Player)
            {
                canMove = true;
                canControl = true;
                CGPlayerList.Instance.playerList.Add(GetComponentInChildren<CGCharacterManager>());
                GetComponentInChildren<CGCharacterManager>().canMove = true;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (canMove)
                HorizontalMovement();
            if (canControl)
                VerticalMovement();
        }

        void HorizontalMovement()
        {
            transform.position += transform.forward * VSpeed * Time.deltaTime;
        }

        void VerticalMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //  FirstPos = transform.position;
                FirstPos = Input.mousePosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                deltaSwip = FirstPos - Input.mousePosition.x;
                FirstPos = Input.mousePosition.x;

            }
            if (Input.GetMouseButtonUp(0))
            {
                deltaSwip = 0;
            }
            transform.position = VerticalMovementCalculate(transform.position, deltaSwip);
        }

        Vector3 VerticalMovementCalculate(Vector3 pos, float delta)
        {
            delta *= VSpeed * Time.deltaTime;
            var clamp = Mathf.Clamp(delta + pos.x, -maxHorizontal, maxHorizontal);
            pos = new Vector3(clamp, pos.y, pos.z);
            return pos;
        }


        private void levelWin()
        {
            canMove = false;
            canControl = false;
        }

        private void levelLose()
        {
            canMove = false;
            canControl = false;
        }

        public float CalculateXline()
        {
            var totalList = CGEnemyList.Instance.enemyList.Count;
            var x = (CGPlayerList.Instance.killedGiant * 10) / totalList;
            var y = Mathf.CeilToInt(x);
            return y;
        }

        public void GoToXline()
        {
            StartCoroutine(GoToXLineCo());
            print("CalculateXline" + CalculateXline());
        }

        IEnumerator GoToXLineCo()
        {
            canControl = false;
            VSpeed = 20f;
            while (transform.position != firstpos)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(firstpos.x, transform.position.y, transform.position.z), 3f * Time.deltaTime);
            }

        }

    }

}
