using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    public class test : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LevelManager.Instance.LevelComplete();
            }
        }
    }
}
