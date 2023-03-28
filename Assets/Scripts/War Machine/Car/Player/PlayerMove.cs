using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace WarMachine
{

    public class PlayerMove : CarController
    {
        [SerializeField] private float speedHorizontal;
        [SerializeField] private Joystick carJoyStick;
        [SerializeField] private float maxHorizontalSpeed;

        [SerializeField] private Transform finishLine;

        private CarShoot _carShoot;
        private HealthControl _healthControl;


        #region Unity Methodes


        protected override void Awake()
        {
            base.Awake();

            Initialized();
        }


        protected override void Update()
        {
            base.Update();

            if (!canMove) return;
            if (_carShoot && _carShoot.target)
            {
                if(_carShoot.target.GetComponent<SplineFollower>())
                follower.followSpeed = _carShoot.target.GetComponent<SplineFollower>().followSpeed;
            }
            else
            {
                follower.followSpeed = SpeedFowrard;
            }

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _healthControl.OnDead -= Dead;

        }

        #endregion

        #region Custom Methodes


        private void Initialized()
        {
            CarJoyStick = carJoyStick;
            MaxHorizontalMove = maxHorizontalSpeed;
            SpeedHorizontal = speedHorizontal;
            _carShoot = GetComponent<CarShoot>();
            TryGetComponent(out _healthControl);
            _healthControl.OnDead += Dead;
        }

        private void Dead()
        {
            if (_carShoot)
            {
                _carShoot.CanShoot = false;
            }
            follower.enabled = false;
            GameManager.Instance.LevelFailed();
        }

        #endregion

        #region Override Methodes

        protected override void OnLevelComplete()
        {
            base.OnLevelComplete();
            finishLine.gameObject.SetActive(true);
        }

        #endregion

    }

}
