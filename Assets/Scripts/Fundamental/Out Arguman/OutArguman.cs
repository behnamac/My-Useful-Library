using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class OutArguman : MonoBehaviour
    {
        private int a, b;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Manager.Instance.GetRandom(out a, out b);
            }
        }
    }
}
