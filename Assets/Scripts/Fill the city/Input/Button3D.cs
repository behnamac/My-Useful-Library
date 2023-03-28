using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FillTheCity
{
    public class Button3D : MonoBehaviour,ITouchable
    {
        public UnityEvent TouchDownAction;

        public void OnTouch(Vector3 point)
        {
        }

        public void OnTouchUp(Vector3 point)
        {

        }


        void ITouchable.OnTouchDown(Vector3 point)
        {
            TouchDownAction?.Invoke();

        }

    }
}

