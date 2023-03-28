using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controllers;
using UnityEngine.SceneManagement;
using Elementary.Scripts.Data.Management;
using DG.Tweening;
using Levels;
using TMPro;


namespace FillTheCity
{
    public class UIController : MonoBehaviour
    {
        #region PUBLIC PROPS

        public static UIController Instance { get; private set; }

        #endregion

        #region SERIALIZE FIELDS

        [Header("Coin")]
        [SerializeField] private Image coinIcon;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private UIElements[] uiElements;

        public TextMeshProUGUI CornTxt;


        #endregion

        #region PRIVATE FIELDS
        private Dictionary<string, UIElements> _uiElementDic;

        #endregion

        #region PRIVATE METHODS

        private void Initializer()
        {
            _uiElementDic = new Dictionary<string, UIElements>();

            for (int i = 0; i < uiElements.Length; i++)
            {
                _uiElementDic.Add(uiElements[i].ProductName, uiElements[i]);
            }

            // Set TotalCoin;
            for (int i = 0; i < uiElements.Length; i++)
            {
                uiElements[i].ProductTxt.text = DataManager.Get<int>(uiElements[i].ProductName).ToString();
            }

        }



        #endregion

        #region PUBLIC METHODS

        public void AddCoin(int coinCount)
        {

            var totalCoin = DataManager.Get<int>("Coin");

            totalCoin += coinCount;

            DataManager.SaveWithJson("Coin", totalCoin);

            coinText.text = totalCoin.ToString();

            coinIcon.transform.DOScale(1.2f, 0.2f).SetEase(Ease.InBounce).OnComplete(() =>
            {
                coinIcon.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InBounce);
            });
        }

        public void ShowProductCount(string product)
        {

            _uiElementDic[product].ProductTxt.text = DataManager.Get<int>(product).ToString();
        }





        #endregion



        #region UNITY EVENT METHODS

        private void Awake()
        {
            Initializer();

            if (Instance == null) Instance = this;
        }


        #endregion
    }

    [System.Serializable]
    public class UIElements
    {
        public string ProductName;
        public TextMeshProUGUI ProductTxt;
    }

}
