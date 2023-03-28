using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public struct baseClass
    {
        public string Name;
        public string Color;
        public int Model;
        public float Gas;
        public bool WindowUp;

        public baseClass(string name, string color, int model, float gas, bool window)
        {
            Name = name;
            Color = color;
            Model = model;
            Gas = gas;
            WindowUp = window;
        }

        //public void Info()
        //{
        //    Debug.Log("Name: " + Name + " Color :" + Color + " Model: " + Model + " gas: " + Gas);
        //}

        public float Drive(float value)
        {
            if (Gas >= 0)
                Gas -= value;
            return Gas;
        }

        //public void Window()
        //{
        //    if (windowUp)
        //    {
        //        Debug.Log("windowUp");
        //        windowUp = false;
        //    }
        //    else
        //    {
        //        Debug.Log("winsow down");
        //        windowUp = true;
        //    }
        //}



        //public void Input()
        //{          
        //        Drive();
        //        Window();
        //        Info();           
        //}
    }
}
