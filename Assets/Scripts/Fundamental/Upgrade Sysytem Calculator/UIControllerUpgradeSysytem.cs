using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Fundamental
{
    public class UIControllerUpgradeSysytem : MonoBehaviour
    {
        public static UIControllerUpgradeSysytem Instance;

        public TextMeshProUGUI MoneyText;

       public float DefaultMoney = 500;



        private void Awake()
        {
            Instance = this;
            var _curentMoney = PlayerPrefs.GetFloat("testMoney", DefaultMoney);
            MoneyText.text = _curentMoney.ToString();
        }


    }

}
