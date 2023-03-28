using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PropertyTest
{
    public class ProperticeProperty : MonoBehaviour
    {
       // [SerializeField] private Property prop;
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private float _firstmoney = 50f;

        private float _money;
        public float Money
        {
            get
            {
                _money = PlayerPrefsController.GetCurrentcy(_firstmoney);
                return _money;
            }
            set
            {
                _money += value;
                PlayerPrefsController.SetCurrency(_money);

            }
        }

        private void Start()
        {
            ShowMoney();

        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SetMoney(10);
            }
        }

        private void SetMoney(float value)
        {
            Money = value;
            ShowMoney();
        }

        private void ShowMoney()
        {
            moneyText.text = Money.ToString();
        }

    }

    public static class PlayerPrefsController
    {
        #region Getter
        public static float GetCurrentcy(float value) => PlayerPrefs.GetFloat("currency", value);
        #endregion

        #region Setter  
        public static void SetCurrency(float value) => PlayerPrefs.SetFloat("currency", value);
        #endregion
    }
}
