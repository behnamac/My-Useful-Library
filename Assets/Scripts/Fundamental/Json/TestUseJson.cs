using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Fundamental
{
    public class TestUseJson : MonoBehaviour
    {
        [SerializeField] private string _intName, _stringName, Name, Family, Job;
        [SerializeField] private int firstValue = 200;
        [SerializeField] private TextMeshProUGUI MyText;
        [SerializeField] private int decreaseAmount = 2;
        private int value;



        private void Start()
        {
            IntClass json = JsonTest.LoadData(_intName);
            if (json == null)
            {
                print("null");
                JsonTest.SaveData(_intName, firstValue);
            }
            else
            {
                value = json.parameter;
                MyText.text = value.ToString();
            }

          

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Calculate(decreaseAmount);
            }
        }

        private void Calculate(int decrease)
        {
            value -= decrease;
            SetValue(value);
        }

        private void SetValue(int value)
        {
            JsonTest.SaveData(_intName, value);
            MyText.text = value.ToString();

        }
    }
}
