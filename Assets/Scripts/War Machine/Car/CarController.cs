using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace WarMachine
{
    public enum StartMoveType
    {
        LoadScene,
        LoadLevel,
        StartGame
    }

    [RequireComponent(typeof(SplineFollower))]
    public class CarController : MonoBehaviour
    {
        public StartMoveType StartMoveType;
        public float SpeedFowrard;
        public RotateObject[] Wheels;

        public SplineFollower follower { get; set; }

        protected float SpeedHorizontal;
        protected float MaxHorizontalMove;
        protected Joystick CarJoyStick;
        protected bool canMove;

        private float _xMove;
        private float _turnAngle;
        private Animator _anim;
        private static readonly int HorizontalTurning = Animator.StringToHash("HrizontalTurning");

        #region unityFunction

        protected virtual void Awake()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFaild += OnLevelFaild;
            GameManager.OnLevelLoad += OnLevelLoad;

            follower = GetComponent<SplineFollower>();
            _anim = GetComponent<Animator>();
            follower.followSpeed = 0;
            if (!follower.spline)
            {
                StartCoroutine(FindSplineComputerCO());
            }
        }

        protected virtual void Start()
        {
            if (StartMoveType==StartMoveType.LoadScene)
            {
                canMove = true;
                follower.followSpeed =SpeedFowrard;
            }

        }

        protected virtual void Update()
        {
            if (canMove&& CarJoyStick)
            {
                HorizontalMove();
            }

        }




        protected virtual void OnDestroy()
        {
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFaild -= OnLevelFaild;
            GameManager.OnLevelLoad -= OnLevelLoad;
        }

        #endregion

        #region Custom Methodes

        private IEnumerator FindSplineComputerCO()
        {
            while (!follower.spline)
            {
                yield return new WaitForEndOfFrame();
                var _computer = FindObjectOfType<SplineComputer>();
                if (_computer)
                {
                    follower.spline = _computer;
                }
            }
        }

        protected virtual void HorizontalMove()
        {
            var _getHorizontalAxis = CarJoyStick.Horizontal;
            var offsetY = follower.motion.offset.y;
            _xMove -= _getHorizontalAxis * SpeedHorizontal * Time.deltaTime;
            _xMove = Mathf.Clamp(_xMove, -MaxHorizontalMove, MaxHorizontalMove);
            follower.motion.offset = new Vector2(_xMove, offsetY);

            _turnAngle = Mathf.MoveTowards(_turnAngle, _getHorizontalAxis, 5 * Time.deltaTime);
            _anim.SetFloat(HorizontalTurning,_turnAngle); 

        }

        protected virtual void OnActiveCar()
        {
            canMove = true;
            follower.followSpeed = SpeedFowrard;
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].Active();
            }
        }

        protected virtual void OnDeactiveCar()
        {
            canMove = false;
            follower.followSpeed = 0;
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].Deactive();
            }
        }

        #endregion


        #region Delegate Methodes

        protected virtual void OnLevelStart()
        {
            if (StartMoveType==StartMoveType.StartGame)
            {
                OnActiveCar();
            }
        }

        protected virtual void OnLevelComplete()
        {
           // Invoke(nameof(OnDeactiveCar), 3);
        }
        protected virtual void OnLevelFaild()
        {
            OnDeactiveCar();
        }
        protected virtual void OnLevelLoad()
        {
            if (StartMoveType==StartMoveType.LoadLevel)
            {
                OnActiveCar();
            }
        }


        #endregion

    }
}
