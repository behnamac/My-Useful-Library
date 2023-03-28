using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Fundamental
{
    public class UpgradeSysytemCalculator : MonoBehaviour
    {
        [SerializeField] protected Button Btn;

        [Header("Power Value")]
        [SerializeField] protected float AddPower;
        [SerializeField] protected float DefaultValue;
        protected int LevelRatio;
        protected float CurrentValue;

        [Header("Price")]
        [SerializeField] protected float DefaultPrice;
        [SerializeField] protected float PriceRatio;
        private float CurrentPrice;

        [Header("Level")]
        [SerializeField] protected string SaveLevel;

        [SerializeField] protected TextMeshProUGUI PriceTxt, LevelText;

        [Header("Money")]
        private float _curentMoney;
        private UIControllerUpgradeSysytem ui;

        [Header("Container text")]
        [SerializeField] protected bool isContainer;
        [ConditionalHide(nameof(isContainer), true)]
        [SerializeField] protected TextMeshProUGUI TargetText;

        protected virtual void Awake()
        {
            ui = UIControllerUpgradeSysytem.Instance;


        }
        protected virtual void Start()
        {
            CurrentPrice = DefaultPrice;
            LoadData();

        }

        private void LoadData()
        {
            _curentMoney = PlayerPrefs.GetFloat("testMoney", ui.DefaultMoney);
            LevelRatio = PlayerPrefs.GetInt(SaveLevel);
            var level = LevelRatio + 1;
            LevelText.text = "Level: " +level;
            PriceCalculate();
            var calcuteValue = DefaultValue+(LevelRatio*AddPower);
            CurrentValue = calcuteValue;
            if (TargetText)
                TargetText.text = CurrentValue.ToString();
        }

        protected virtual void Button()
        {
            if (!CalculateMoney(CurrentPrice)) return;
            LevelTextCalculate();
            Upgrade();
            PriceCalculate();
        }

        protected virtual void LevelTextCalculate()
        {
            LevelRatio += 1;
            var level = LevelRatio + 1;
            LevelText.text = "Level: " + level.ToString();
            PlayerPrefs.SetInt(SaveLevel, LevelRatio);
        }

        protected virtual void Upgrade()
        {
            var calcuteValue = DefaultValue + (LevelRatio * AddPower);
            CurrentValue = calcuteValue;
            if (TargetText)
                TargetText.text = CurrentValue.ToString();
        }

        private void PriceCalculate()
        {
            var calculate = DefaultPrice + (LevelRatio * PriceRatio);
            CurrentPrice = calculate;
            PriceTxt.text = CurrentPrice + " $".ToString();
        }

        public bool CalculateMoney(float value)
        {

            if (_curentMoney >= value)
            {
                _curentMoney -= value;
                PlayerPrefs.SetFloat("testMoney", _curentMoney);
                ui.MoneyText.text = _curentMoney.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
