using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{


    public class PlayerWrestle : Wreslers
    {

        [SerializeField] private float maxStamina;
        [SerializeField] private float speedSpentStamina;
        [SerializeField] private float speedDownWrestle;

        private PlayerMove _playerMove;

        private List<float> _staminaWaveValue;

        protected float _currentPower;

        private float _currentMaxStamina;
        private float _currentStamina;
        private float _minStamina;
        private float _enemyPower;


        #region Unity Methodes

        protected override void OnEnable()
        {
            base.OnEnable();
            LevelManager.OnLoadLevel += OnLoadLevel;
            LevelManager.OnLevelStart += OnLevelStart;
            LevelManager.OnLevelFail += OnLevelFail;

        }
        protected override void OnDisable()
        {
            base.OnDisable();
            LevelManager.OnLoadLevel -= OnLoadLevel;
            LevelManager.OnLevelStart -= OnLevelStart;
            LevelManager.OnLevelFail -= OnLevelFail;

        }

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out _playerMove);
            _staminaWaveValue = new List<float>();
            _currentPower = Power;
            _currentMaxStamina = maxStamina;
        }

        protected override void Start()
        {
            base.Start();

        }

        protected override void Update()
        {
            base.Update();
        }

        #endregion

        #region Action Methodes

        public override void Death()
        {
            base.Death();
        }

        protected override void OnLoadLevel(Level level)
        {
            base.OnLoadLevel(level);
            var getSliderDivide = WaveHolder.GetMaxSliderDivide();
            var staminaWaveCount = _currentMaxStamina / getSliderDivide;
            for (int i = 0; i < getSliderDivide; i++)
            {
                _staminaWaveValue.Add(staminaWaveCount * i);
            }
        }

        protected override void OnLevelStart(Level level)
        {
            base.OnLevelStart(level);
            _enemyPower = WaveHolder.Instance._enemyPowers[0];

        }

        protected override void OnLevelFail(Level level)
        {
            base.OnLevelFail(level);
            Death();
        }


        #endregion

        #region Custom Methodes

        protected override void DoWrestel()
        {
            base.DoWrestel();
            if (Input.GetMouseButton(0))
            {
                WrestleAnimValue += (_currentPower - _enemyPower) * Time.deltaTime;
                _currentStamina += speedSpentStamina * Time.deltaTime;
            }
            else
            {
                WrestleAnimValue -= speedDownWrestle * Time.deltaTime;
                _currentStamina -= speedSpentStamina * Time.deltaTime;

            }
            for (int i = 0; i < _staminaWaveValue.Count; i++)
            {

                if (_minStamina < _staminaWaveValue[i] && _currentStamina >= _staminaWaveValue[i])
                {
                    _minStamina = _staminaWaveValue[i];
                }
            }
            _currentStamina = Mathf.Clamp(_currentStamina, _minStamina, _currentMaxStamina);
            UIManager.Instance.SetStaminaBar(_currentStamina / _currentMaxStamina);

            if (_currentStamina >= _currentMaxStamina)
            {
                LevelManager.Instance.LevelFail();
            }

            if (WrestleAnimValue >= 1)
            {
                WrestleAnimValue = 0;
                CanWrestle = false;
                WaveHolder.Instance.RemoveEnemy();
                _enemyPower = WaveHolder.Instance._enemyPowers[0];
                _playerMove.GotoNextPoint();
            }

          var alert=CalculateEnergySpend(_currentStamina, _currentMaxStamina);
            if (alert >= 0.8)
                print("you are tired");
            
        }

        public void UpgradeStamina(float value)
        {
            _currentMaxStamina += value;
            //print("_currentMaxStamina: "+_currentMaxStamina);
        }

        public void UpgradePower(float value)
        {
            _currentPower += value;
            //print("_currentPower: " + _currentPower);
        }

        private float CalculateEnergySpend(float currentS, float maxS)
        {
            var devide = currentS / maxS;
            return devide;
        }


        #endregion



    }
}
