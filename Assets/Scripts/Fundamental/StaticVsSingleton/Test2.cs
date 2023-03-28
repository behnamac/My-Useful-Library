using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class Test2 : MonoBehaviour
    {
        public float variable = 3.3f;
        public string Name = "ali";
        public int Intvariable = 5;
        // Start is called before the first frame update
        void Start()
        {
            TestSingleton();
            TestStatic();
        }

        private void TestSingleton()
        {
            var num1 = Singleton.Instance.CalNum1(variable);
            var name = Singleton.Instance.CalString(Name);
            var num2 = Singleton.Instance.CalInt(Intvariable);
            print("Sigleton Float: " + num1 + " Sigleton String: " + name + " Sigleton Int: " + num2);
        }

        private void TestStatic()
        {
            var num1 = Static.CalNum1(1.3f);
            var name = Static.CalString("ahmad");
            var num2 = Static.CalInt(2);
            print("Static Float: " + num1 + " Static String: " + name + " Static Int: " + num2);
        }



    }
}
