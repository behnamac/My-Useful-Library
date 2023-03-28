using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WrestleBreaker
{
    public class UpgradeController : MonoBehaviour
    {
        [Header("Button")]
        public Button PowerBtn;
        public Button StaminaBtn;
        public Button IncomeBtn;

        [Header("Text")]
        [SerializeField] private Text powerLevelTxt;
        [SerializeField] private Text powerPriceTxt;
        [SerializeField] private Text staminaLevelTxt;
        [SerializeField] private Text staminaPriceTxt;
        [SerializeField] private Text IncomePriceTxt;
        [SerializeField] private Text IncomeLevelTxt;

        [Header("Power")]
        [SerializeField] private int firstPowerPrice;
        [SerializeField] private float addPowerValue;
        [SerializeField] private int addPowerPrice;

        [Header("Income")]
        [SerializeField] private int firstIncomePrice;
        [SerializeField] private float addIncomeValue;
        [SerializeField] private int addIncomePrice;

        [Header("Stamina")]
        [SerializeField] private int firstStaminaPrice;
        [SerializeField] private float addStaminaValue;
        [SerializeField] private int addStaminaPrice;

        [SerializeField] private PlayerWrestle _playerWrestle;

        private int _powerLevel;
        public int PowerLevel
        {
            get
            {
                _powerLevel = PlayerPrefsController.GetPowerLevel();
                return _powerLevel;
            }
            set
            {
                _powerLevel = value;
                PlayerPrefsController.SetPowerLevel(_powerLevel);
            }
        }

        private int _staminaLevel;
        public int StaminaLevel
        {
            get
            {
                _staminaLevel = PlayerPrefsController.GetStaminaLevel();
                return _staminaLevel;
            }
            set
            {
                _staminaLevel = value;
                PlayerPrefsController.SetStaminaLevel(_staminaLevel);
            }
        }
        private int _incomeLevel;
        public int IncomeLevel
        {
            get
            {
                _incomeLevel = PlayerPrefsController.GetIncomeLevel();
                return _incomeLevel;
            }
            set
            {
                _incomeLevel = value;
                PlayerPrefsController.SetIncomeLevel(_incomeLevel);
            }
        }

        private int _powerPrice;
        private int _staminaPrice;
        private int _incomePrice;

        


        #region Unity Methodes

        private void Awake()
        {
            _powerPrice = firstPowerPrice;
            _staminaPrice = firstStaminaPrice;
            _incomePrice = firstIncomePrice;
        }

        private void Start()
        {
            PowerBtn.GetComponent<Button>().onClick.AddListener(UpgradePower);
            StaminaBtn.GetComponent<Button>().onClick.AddListener(UpgradeStamina);
            IncomeBtn.GetComponent<Button>().onClick.AddListener(UpgradeIncome);
            loadData();
        }

        #endregion

        #region Custom Methodes

        private void loadData()
        {
            _playerWrestle.UpgradePower(PowerLevel * addPowerValue);
            _playerWrestle.UpgradeStamina(StaminaLevel * addStaminaPrice);

            _powerPrice += addPowerPrice * PowerLevel;
            _staminaPrice += addStaminaPrice * StaminaLevel;
            _incomePrice += addIncomePrice * IncomeLevel;

            UpdatePowerTexts(PowerLevel,_powerPrice);
            UpdateStaminaTexts(StaminaLevel, _staminaPrice);
            UpdateIncomeTexts(IncomeLevel, _incomePrice);

        }

        private void UpgradeStamina()
        {
            if (!calculateMoney(_staminaPrice)) return;
            StaminaLevel++;
            _staminaPrice += addStaminaPrice * StaminaLevel;
            UpdateStaminaTexts(StaminaLevel, _staminaPrice);
            _playerWrestle.UpgradeStamina(addStaminaPrice);
        }

        private void UpgradeIncome()
        {
            if (!calculateMoney(_incomePrice)) return;
            IncomeLevel++;
            _incomePrice += addIncomePrice * IncomeLevel;
            UpdateIncomeTexts(IncomeLevel, _incomePrice);

        }

        private void UpgradePower()
        {
            if (!calculateMoney(_powerPrice)) return;
            PowerLevel++;
            UpdatePowerTexts(PowerLevel, _powerPrice);
            _playerWrestle.UpgradePower(addPowerValue);


        }

        private bool calculateMoney(float value)
        {
            var money = UIManager.Instance.Money;
            if (money >= value)
            {
                UIManager.Instance.Money -= value;
                UIManager.Instance.ShowCoin();
                return true;

            }
            else
            {
                return false;
            }
        }

        public void UpdatePowerTexts(int level, int price)
        {
            powerLevelTxt.text = "Level:" + (level + 1);
            powerPriceTxt.text = price + "$";
        }
        public void UpdateStaminaTexts(int level, int price)
        {
            staminaLevelTxt.text = "Level:" + (level + 1);
            staminaPriceTxt.text = price + "$";
        }
        public void UpdateIncomeTexts(int level, int price)
        {
            IncomeLevelTxt.text = "Level:" + (level + 1);
            IncomePriceTxt.text = price + "$";
        }

        

        #endregion

    }
}
