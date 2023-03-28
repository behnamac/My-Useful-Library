using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fundamental
{
    public class HealthUpgrade : UpgradeSysytemCalculator
    {

        protected override void Awake()
        {
            base.Awake();

        }

        protected override void Start()
        {
            base.Start();


            Btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                Button();
            });
        }

        protected override void Button()
        {
            base.Button();
            print("ovverride");

        }

        
    }
}
