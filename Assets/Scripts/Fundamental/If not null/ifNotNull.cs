using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public enum mode { oldWay, NewWay }

    public class ifNotNull : MonoBehaviour
    {
        [SerializeField] private GameObject sample;
        [SerializeField] private mode mode;
        private void Start()
        {
            if (mode == mode.NewWay)
            {
                if (sample)
                {
                    print("full");
                }
                else if (!sample)
                {
                    print("empty");
                }
            }
            else
            {
                if (sample != null)
                {
                    print("full");
                }
                else if (sample == null)
                {
                    print("empty");
                }
            }
        }
    }
}
