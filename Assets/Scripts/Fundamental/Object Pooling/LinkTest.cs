using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class LinkTest : MonoBehaviour
    {
        [SerializeField]private string text;

        public void SetText(string value)
        {
            text = value;
            print(text);

        }
    }
}
