using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace WrestleBreaker
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private Button startBtn;
        [SerializeField] private Image StaminaFill;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private float firstMoney;

        private float _money;
        public float Money
        {
            get
            {
                _money = PlayerPrefsController.GetCurrentcy(firstMoney);
                return _money;
            }
            set
            {
                _money = value;
                PlayerPrefsController.SetCurrency(_money);
            }
        }

        


        private void OnEnable()
        {
            LevelManager.OnLevelComplete += OnLevelComplete;
            LevelManager.OnLevelFail += OnLevelFail;
            LevelManager.OnLevelStart += OnLevelStart;
        }

        protected void OnDisable()
        {
            LevelManager.OnLevelComplete -= OnLevelComplete;
            LevelManager.OnLevelFail -= OnLevelFail;
            LevelManager.OnLevelStart -= OnLevelStart;
        }

        private void Awake()
        {
           if(!Instance)
                Instance = this;
            ShowCoin();
        }

        private void Start()
        {
            startBtn.onClick.AddListener(() =>
            {
                LevelManager.Instance.LevelStart();
            });
            winPanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
            losePanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }

        #region Custom Events

        public void SetStaminaBar(float value)
        {
            StaminaFill.fillAmount = value;
        }

        

        public void ShowCoin()
        {
            coinText.text = Money.ToString();
        }

        

        public void SetCoin(float value)
        {
            var incomeLevel = PlayerPrefsController.GetIncomeLevel();
            Money += incomeLevel + value;
            ShowCoin();
        }

        #endregion



        #region Delegate Methodes

        private void OnLevelComplete(Level level)
        {
            winPanel.gameObject.SetActive(true);
        }

        private void OnLevelFail(Level level)
        {
            losePanel.gameObject.SetActive(true);
        }
        private void OnLevelStart(Level level)
        {
            startPanel.gameObject.SetActive(false);

        }
        #endregion
    }
}
