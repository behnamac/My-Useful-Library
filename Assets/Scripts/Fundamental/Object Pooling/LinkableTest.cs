using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
public class LinkableTest : MonoBehaviour
{
        private string Text="hello";
        [SerializeField] private LinkTest linkGameObject;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Create(); 
            }
        }

        private void Create()
        {
            Instantiate(linkGameObject);
            linkGameObject.SetText(Text);
            
        }
    }
}
