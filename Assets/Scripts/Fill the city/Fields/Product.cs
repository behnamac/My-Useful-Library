using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Elementary.Scripts.Data.Management;

namespace FillTheCity
{
    public class Product : MonoBehaviour, iAgriculture, ITouchable
    {
        public bool Getable { get; set; }
        [SerializeField] private GameObject _meshHolder;
        [SerializeField] private GameObject[] fruits;
        [SerializeField] private float maxScale = 0.048f;
        [SerializeField] private SaveSystem Warehouse;
        [SerializeField] private GameObject fakeProduct;
        [SerializeField] private string productName;

        private Vector3 _defaultScale;
        private int productValue;
   

        #region Unity Methods
        private void OnEnable()
        {
            _meshHolder.gameObject.SetActive(true);

        }
        private void Awake()
        {
            _defaultScale = _meshHolder.transform.localScale;
            productValue = DataManager.Get<int>(productName);
            gameObject.SetActive(false);
            if (!Warehouse)
                Warehouse = FindObjectOfType<SaveSystem>();
        }   


        #endregion


        public void AnimProcessing(float length)
        {
            _meshHolder.transform.DOScale(1, length).OnComplete(() =>
            {
                if (fruits == null) return;
                for (int i = 0; i < fruits.Length; i++)
                {

                    fruits[i].transform.DOScale(maxScale, (i + 1) * 0.6f);
                }
                Getable = true;

            });
        }


        public void GetProduct()
        {
            if (!Getable) return;
            Getable = false;
            _meshHolder.gameObject.SetActive(false);
            var _fakeproduct = Instantiate(fakeProduct, transform.position, transform.rotation);
            _fakeproduct.transform.DOJump(Warehouse.transform.position, 2, 1, 0.5f).OnComplete(() =>
            {
                productValue = DataManager.Get<int>(productName);
                productValue += 1;
                DataManager.SaveWithJson(productName, productValue);
                UIController.Instance.ShowProductCount(productName);
                Destroy(_fakeproduct);
                ResetSize();
            });

        }

        private void ResetSize()
        {
            _meshHolder.transform.localScale = _defaultScale;
            gameObject.SetActive(false);

            foreach (var item in fruits)
            {
                item.transform.localScale = Vector3.zero;
            }



        }

        public void OnTouchDown(Vector3 point)
        {
            // GetProduct();
        }

        public void OnTouch(Vector3 point)
        {
            GetProduct();
        }

        public void OnTouchUp(Vector3 point)
        {

        }
    }

}
