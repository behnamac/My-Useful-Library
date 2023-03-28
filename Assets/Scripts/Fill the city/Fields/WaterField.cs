using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FillTheCity
{
    public class WaterField : MonoBehaviour
    {
        public bool LetFill { get; set; }
        [HideInInspector] public int MaxWater = 100;
        //to do: check for can we have enough water for active reduce water button
        [SerializeField] private float timerSpeed = 0.2f;
        [SerializeField] private float speed = 10;
        [SerializeField] private TextMeshProUGUI waterText;
        [SerializeField] private Transform waterModel;

        private float _currentTime;
        private bool _isFull;

        private float _waterValue;
        public float WaterValue
        {
            get
            {
                return _waterValue;
            }
            set
            {
                _waterValue = value;
            }
        }

        #region Unity Methods

        private void Start()
        {
            LetFill = true;
            waterModel.localPosition = new Vector3(0, GetWaterAmountValue(), 0);
        }

        private void Update()
        {
            Timer();
        }
        #endregion

        private void Timer()
        {
            if (_isFull) return;
            _currentTime += Time.deltaTime;
            if (_currentTime >= timerSpeed)
            {
                WaterFilling();
                _currentTime = 0;
            }
        }



        public void WaterFilling()
        {
            if (!LetFill) return;
            if (WaterValue >= MaxWater)
            {
                _isFull = true;
                WaterValue = Mathf.Clamp(WaterValue, 0, MaxWater);
                return;
            }
            WaterValue++;
            waterModelIncrease(GetWaterAmountValue());
            textUpdate();
        }

        private float GetWaterAmountValue()
        {
            var _water = (float)WaterValue / (float)MaxWater;
            return _water;
        }

        private void waterModelIncrease(float value)
        {
            waterModel.localPosition = new Vector3(0, value * 5, 0);
        }

        public void waterReducing(int value, int count)
        {
            _isFull = false;
            //            print("before:" + WaterValue);
            float multi = (float)value * count;
            WaterValue += multi;
            //          print(multi);
            //        print("after:" + WaterValue);
            textUpdate();
        }

        private void textUpdate()
        {
            var water = Mathf.Clamp(WaterValue, 0, MaxWater);
            waterText.text = water.ToString("F0") + "/100";
        }


    }

}
