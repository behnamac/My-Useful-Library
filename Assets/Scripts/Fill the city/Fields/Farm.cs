using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FillTheCity
{
    public class Farm : Field
    {
        [SerializeField] private Product[] products;
        [SerializeField] private float distanceTouch = 2f;
        [SerializeField] private ParticleSystem[] waterParticle;
        private List<Product> activeProducts;

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            Initialized();
        }
        protected override void Update()
        {
            base.Update();
            if (!CanCheckWater) return;
            CheckReduceable(activeProducts.Count, waterAmount);

        }

        #endregion       

        private void AddProduct(Vector3 point)
        {
            CanCheckWater = true;
            var product = CheckDistance(point);
            if (!product) return;
            product.gameObject.SetActive(true);
            activeProducts.Add(product);
        }


        private Product CheckDistance(Vector3 point)
        {
            for (int i = 0; i < products.Length; i++)
            {
                float distance = Vector3.Distance(products[i].transform.position, point);
                if (distance <= distanceTouch && !products[i].gameObject.activeInHierarchy)
                {
                    return products[i];
                }

            }
            return null;
        }

        protected override void ProductProcess()
        {
            base.ProductProcess();
            water.waterReducing(-waterAmount, activeProducts.Count);
            PlayAnimation();
        }

        protected override void PlayAnimation()
        {
            base.PlayAnimation();
            StartCoroutine(waterPrticleCO());
            foreach (var item in activeProducts)
            {
                float delay = 0.6f;
                item.AnimProcessing(delay);
            }
            RemoveList();
        }
        private IEnumerator waterPrticleCO()
        {
            foreach (var item in waterParticle)
            {
                item.GetComponent<ParticleSystem>().Play();
            }
            // waterParticle.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            foreach (var item in waterParticle)
            {
                item.GetComponent<ParticleSystem>().Stop();
            }
            water.LetFill = true;
        }

        //private void SaveToStorage()
        //{
        //    int productNum = activeProducts.Count;
        //    SaveSystem.Instance.Corn = productNum;
        //}
        

        private void RemoveList()
        {
            activeProducts.Clear();
        }
        protected override void AddToList()
        {
            base.AddToList();
        }




        public override void OnTouchDown(Vector3 point)
        {
            base.OnTouchDown(point);

        }

        public override void OnTouch(Vector3 point)
        {
            if (!CanTouch) return;
            base.OnTouch(point);
            AddProduct(point);
        }

        public override void OnTouchUp(Vector3 point)
        {
            base.OnTouchUp(point);

        }


        private void Initialized()
        {
            activeProducts = new List<Product>();
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < products.Length; i++)
            {

                Gizmos.DrawWireSphere(products[i].transform.position, distanceTouch);
            }
        }
    }

}
