using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FillTheCity
{
    public abstract class Field : MonoBehaviour, ITouchable
    {
        [SerializeField] protected Button3D waterBtn;
        [SerializeField] protected int waterAmount;
        [SerializeField] protected WaterField water;
        protected bool CanCheckWater;
        protected bool CanTouch;


        // [SerializeField] private Vector3 distanceTouch=Vector3.one;

        private float CornAmount;
        private float waitingSpeed;
        private float capacity;
        //private Vector3 _touch = Vector3.one * 1000;


        #region Unity Methods
        protected virtual void Awake()
        {
            Initialized();
        }

        protected virtual void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                CanTouch = false;
            }
        }
        #endregion

        // check do have enough water or not
        protected virtual bool checkWater(float value)
        {
            if (value <= water.WaterValue)
                return true;
            return false;
        }

        //If we have enought water, product gonna be grow
        protected virtual void CheckReduceable(int productCount,float waterCount)
        {
            if (!CanCheckWater) return;
            var waterNeed = productCount * waterAmount;
            waterNeed = Mathf.Clamp(waterNeed, 0, water.MaxWater);
            //print(waterNeed);
            if (waterNeed <= water.WaterValue)
                waterBtn.transform.DOScale(1, 0.3f);
            else
            {
                waterBtn.transform.DOScale(0, 0.3f);
            }

        }

        protected virtual void ProductProcess()
        {
            water.LetFill = false;
            CanCheckWater = false;
            waterBtn.transform.DOScale(0, 0.3f);

        }

        protected virtual void PlayAnimation()
        {
            AddToList();
        }
        protected virtual void AddToList()
        {

        }


        private void Initialized()
        {
            if (!water)
                water = FindObjectOfType<WaterField>();
            if (!waterBtn)
                waterBtn = GetComponentInChildren<Button3D>();

        }


        public virtual void OnTouchDown(Vector3 point)
        {
            CanTouch = true;
        }

        public virtual void OnTouch(Vector3 point)
        {
        }

        public virtual void OnTouchUp(Vector3 point)
        {
        }



    }

}
