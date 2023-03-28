using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DestroyTheInfected
{
    public class UiController : MonoBehaviour
    {
        public static UiController Instance;

        [Header("All Panels")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject StartPanel;
        [SerializeField] private GameObject GamePlayPanel;
        private Button startBtn;

        public Image healthBar;

        [Header("Coin")]
        [SerializeField] private Text coinText;

        [Header("Virus")]
        [SerializeField] private Text virusText;


        private void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelFail += OnLevelFail;
            GameManager.OnLevelComplete += OnLevelComplete;


        }

        private void Awake()
        {
            Instance = this;
            startBtn = StartPanel.gameObject.GetComponentInChildren<Button>();

            startBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.LevelStart();
            });

            // Invoke(nameof(Initialize),0.1f);
        }

        private void OnLevelStart()
        {
            StartPanel.gameObject.SetActive(false);
            GamePlayPanel.gameObject.SetActive(true);
            Initialize();
        }

        private void OnLevelFail()
        {
            GamePlayPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);
        }

        private void OnLevelComplete()
        {
            GamePlayPanel.gameObject.SetActive(false);
            winPanel.gameObject.SetActive(true);
        }

        public void AddCoin(int value)
        {
            var data = DataController.Instance.collectable;
            data.TotalCoin += value;
            PlayerPrefsController.SetTotalCurrency(data.TotalCoin);
            coinText.text = data.TotalCoin.ToString();
        }

        public void AddHealth()
        {
            var data = DataController.Instance.collectable;
            data.PlayerCurrentHealth += data.CollectablerHealthValue;
            healthBar.fillAmount = data.PlayerCurrentHealth / data.PlayerMaxHealth;

        }

        public void UpdateHealth(float value)
        {
            var data = DataController.Instance.collectable;
            healthBar.fillAmount = value/ data.PlayerMaxHealth;
            print("value/ data.PlayerMaxHealth: " + data.PlayerMaxHealth);

        }

        public void UpdateVirusText(int value)
        {
            virusText.text = value.ToString();
        }


        private void Initialize()
        {
            var data = DataController.Instance.collectable;
            data.TotalCoin = PlayerPrefsController.GetTotalCurrency();
            coinText.text = data.TotalCoin.ToString();
            data.PlayerCurrentHealth = data.PlayerMaxHealth;
            healthBar.fillAmount = data.PlayerCurrentHealth;
        }

    }
}
