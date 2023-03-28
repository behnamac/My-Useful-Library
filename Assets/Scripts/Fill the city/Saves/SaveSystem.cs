using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Elementary.Scripts.Data.Management;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FillTheCity
{
    public class SaveSystem : MonoBehaviour
    {
        public static SaveSystem Instance;

        [SerializeField] private StorageProduct[] products;

        private Dictionary<string, StorageProduct> productsDic;





        #region Water

        #endregion


        #region UnityMethod

        private void Awake()
        {
            Instance = this;

            productsDic = new Dictionary<string, StorageProduct>();
            for (int i = 0; i < products.Length; i++)
            {
                productsDic.Add(products[i].Name, products[i]);
            }
        }

        private void Start()
        {
//            LoadData(productsDic["Corn"].Name);
//            print(productsDic["Corn"].Amount);
        }

        #endregion



        public void SaveData(string product, int value)
        {
            var _productVal = productsDic[product].Amount + value;
            DataManager.SaveWithJson(product, _productVal);

        }

        private int LoadData(string fileName)
        {
            return 0;
        }


        [System.Serializable]
        public class StorageProduct
        {
            public string Name;
            public int Amount;
        }

        #region Menu

#if UNITY_EDITOR

        [MenuItem("Json/DeleteFile")]
        private static void DeleteJsonFile()
        {
            // FileUtil.DeleteFileOrDirectory(_path);
        }

#endif

        #endregion
    }

}
