using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class Static : MonoBehaviour
    {
        public static float StaticNum1 = 20.3f;
        public static string StaicString1 = "Behnam";
        public static int StaticInt1 = 5;

        public static float CalNum1(float value)
        {
            StaticNum1 += value;
            return StaticNum1;
        }
        public static string CalString(string value)
        {
            StaicString1 = value;
            return StaicString1;
        }
        public static int CalInt(int value)
        {
            StaticInt1 += value;
            return StaticInt1;
        }
    }
}
