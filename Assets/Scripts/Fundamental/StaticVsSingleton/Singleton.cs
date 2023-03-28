using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fundamental
{
    public class Singleton : MonoBehaviour
    {
        public static Singleton Instance;

        public float SingletonNum1 = 20.3f;
        public string SingletonString1 = "Behnam";
        public int SingletonInt1 = 5;

        private void Awake()
        {
            Instance = this;
        }
        public float CalNum1(float value)
        {
            SingletonNum1 += value;
            return SingletonNum1;
        }
        public string CalString(string value)
        {
            SingletonString1 = value;
            return SingletonString1;
        }
        public int CalInt(int value)
        {
            SingletonInt1 += value;
            return SingletonInt1;
        }
    }
}
