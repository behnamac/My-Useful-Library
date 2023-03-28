using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Fundamental
{
    public class IsPointerOver : MonoBehaviour
    {
        [SerializeField] private bool _canTouch;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _canTouch = true;
            }
            if (_canTouch)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("You Touched everywhere !");
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    print("You Touched!");
                }
            }
        }
    }

}
