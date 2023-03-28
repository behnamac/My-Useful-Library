using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

namespace WarMachine
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("Panels")]
        [Space(5)]
        [SerializeField] private GameObject WinPanel;
        [SerializeField] private GameObject LosePanel;
        [SerializeField] private GameObject GamePlayPanel;
        [SerializeField] private GameObject StartPanel;
        [SerializeField] private Button startBtn;

        [Header("Coin")]
        [SerializeField] private Image coinIcon;
        [SerializeField] private Text coinText;
        [SerializeField] private Image[] levelFinishCoins;
        [SerializeField] private Text levelFinishCoinText;
        private int _totalCoin;

        [Header("Bars")]
        [Space(5)]
        [SerializeField] private Image progressBar;

        [Header("Upgrade")]
        public Button upgradeHealthButton;
        public Button upgradeDamageButton;
        [SerializeField] private Text healthLevel;
        [SerializeField] private Text healthprice;
        [SerializeField] private Text damageLevel;
        [SerializeField] private Text damagePrice;
        [SerializeField] private Image levelUpgradeBar;
        [SerializeField] private TextMeshProUGUI levelUpgradeText;



        #region Unity Methodes

        private void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFaild += OnLevelFaild;

        }
        private void OnDisable()
        {
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFaild -= OnLevelFaild;

        }

        private void Awake()
        {
            Instance = this;
            Initialized();
        }

        #endregion

        #region Custom Methodes

        public void Progressbar(float value)
        {
            progressBar.fillAmount = value;
        }

        public void AddCoin(int coinCount)
        {
             _totalCoin = PlayerPrefsController.GetTotalCurrency();
            _totalCoin += coinCount;
            PlayerPrefsController.SetCurrency(_totalCoin);
            coinText.text = _totalCoin.ToString();
            coinIcon.transform.DOScale(1.2f, 0.2f).SetEase(Ease.InBounce).OnComplete(() =>
            {
                coinIcon.transform.DOScale(1.0f, 0.2f).SetEase(Ease.InBounce);
            });
        }

        public void UpdateCoinText()
        {
            _totalCoin = PlayerPrefsController.GetTotalCurrency();
            coinText.text = _totalCoin.ToString();
        }


        #region Upgrade Area

        public void UpdateHealthText(int level,int price)
        {
            healthLevel.text = "Level " + level;
            healthprice.text=price+ " $";
        }
        public void UpdateDamageText(int level,int price)
        {
            damageLevel.text = "Damage" + level;
            damagePrice.text=price+ "$";
        }
        public void UpdateUpgradeLevel(float bar,int level)
        {
            levelUpgradeBar.fillAmount = bar;
            levelUpgradeText.text = "Level: " + level;
        }
        

        #endregion





        private void Initialized()
        {

            startBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.LevelStart();
            });

            WinPanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            LosePanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });

            coinText.text = PlayerPrefsController.GetTotalCurrency().ToString();


        }

        #endregion

        #region DelegateMethode

        private void OnLevelStart()
        {
            StartPanel.gameObject.SetActive(false);
            GamePlayPanel.gameObject.SetActive(true);
        }
        private void OnLevelComplete()
        {
            WinPanel.gameObject.SetActive(true);

        }
        private void OnLevelFaild()
        {
            LosePanel.gameObject.SetActive(true);

        }

        #endregion
    }
}
