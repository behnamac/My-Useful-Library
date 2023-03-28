using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class PlayerUpgrade : MonoBehaviour
    {
        [SerializeField] private UpgradeHolder[] upgradeHolders;

        [Header("Upgrade Health")]
        [SerializeField] private float addHealth;
        [SerializeField] private int PriceHealthRatio;
        [SerializeField] private int upgradeHealthPrice;

        [Header("Upgrade Damage")]
        [SerializeField] private float addDamage;
        [SerializeField] private int PriceDamageRatio;
        [SerializeField] private int upgradeDamagePrice;

        [Header("DeveloperMode")]
        [SerializeField] private bool developmerMode;
        [ConditionalHide(nameof(developmerMode), true)]
        [SerializeField] private int fakeMoney = 1000;

        private int _currentMoney;
        private int _currentHealthPrice;
        private int _currentDamagePrice;
        private HealthControl _playerHealth;
        private CarShoot _playerShoot;




        private void Awake()
        {
            AwakeInitialized();

        }

        private void Start()
        {
            StartInitialized();
        }






        #region Custom Methodes

        private void AwakeInitialized()
        {
            _playerHealth = GetComponent<HealthControl>();
            _playerShoot = GetComponent<CarShoot>();
            _currentHealthPrice = upgradeHealthPrice;
            _currentDamagePrice = upgradeDamagePrice;
            if (developmerMode) DevelopeerMode();
        }

        private void StartInitialized()
        {
            UIManager.Instance.UpdateUpgradeLevel(0, 1);
            int healthRatio = PlayerPrefsController.GetHealth();
            int damageRatio = PlayerPrefsController.GetDamage();
            _playerHealth.UpgradeMaxHealth(healthRatio * addHealth);
            _currentHealthPrice += PriceHealthRatio * healthRatio;
            _currentDamagePrice += PriceDamageRatio * damageRatio;
            _playerShoot.damageBullet += PlayerPrefsController.GetDamage() * addDamage;

            UIManager.Instance.UpdateHealthText(healthRatio + 1, _currentHealthPrice);
            UIManager.Instance.UpdateDamageText(damageRatio + 1, _currentDamagePrice);
            UIManager.Instance.upgradeHealthButton.onClick.AddListener(UpgradeHealth);
            UIManager.Instance.upgradeDamageButton.onClick.AddListener(UpgradeDamage);



        }

        private void UpgradeHealth()
        {
            if (!CheckMoney(_currentHealthPrice,true)) return;
            _playerHealth.UpgradeMaxHealth(addHealth);
            _currentHealthPrice += PriceHealthRatio;
            int healthNum = PlayerPrefsController.GetHealth();
            PlayerPrefsController.SetHealth(healthNum + 1);
            UIManager.Instance.UpdateHealthText(PlayerPrefsController.GetHealth() + 1, _currentHealthPrice);
            UIManager.Instance.UpdateCoinText();
        }

        private void UpgradeDamage()
        {
            if (!CheckMoney(_currentHealthPrice,true)) return;
            _playerShoot.UpgradeBulletDamage(addDamage);
            _currentDamagePrice += PriceDamageRatio;
            int damageNum = PlayerPrefsController.GetDamage();
            PlayerPrefsController.SetDamage(damageNum + 1);
            UIManager.Instance.UpdateDamageText(PlayerPrefsController.GetDamage() + 1, _currentDamagePrice);
            UIManager.Instance.UpdateCoinText();
        }


        private bool CheckMoney(int value, bool buy)
        {
            int money = PlayerPrefsController.GetTotalCurrency();
            if (money < value)
                return false;
            else
            {
                if (buy) PlayerPrefsController.SetCurrency(money - value);
                return true;
            }
        }

        public void MoneyForUpgrade(int value)
        {
            _currentMoney += value;
            int levelUpgrade = 0;
            for (int i = 0; i < upgradeHolders.Length; i++)
            {
                if (CheckMoney(upgradeHolders[i].TargetMoney,false) && !upgradeHolders[i].active)
                {
                    levelUpgrade++;
                    for (int j = 0; j < upgradeHolders[i].Objects.Length; j++)
                    {
                        upgradeHolders[i].Objects[j].gameObject.SetActive(true);
                    }
                }

            }
            levelUpgrade = Mathf.Clamp(levelUpgrade, 0, upgradeHolders.Length - 1);
            float bar = (float)_currentMoney / upgradeHolders[levelUpgrade].TargetMoney;
            UIManager.Instance.UpdateUpgradeLevel(bar, levelUpgrade + 1);
        }

        private void DevelopeerMode()
        {
            PlayerPrefsController.SetCurrency(fakeMoney);
        }

        #endregion

    }

    [System.Serializable]
    public class UpgradeHolder
    {
        public int TargetMoney;
        public GameObject[] Objects;
        [HideInInspector] public bool active;
    }
}
