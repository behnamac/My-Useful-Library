using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance;
        private void Awake() => Instance=this;        
            
        
        public void GetRandom(out int a, out int b)
        {
            a = Random.Range(0, 100);
            b = Random.Range(0, 100);
            print("a: " + a + "b: " + b);
            print(sum(a, b));
        }

        private int sum(int a, int b)
        {
            var _sum = a + b;

            return _sum;
        }

    }
}
