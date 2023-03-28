using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DistanceTouch
{
    public class DİstanceTouch : MonoBehaviour
    {
        public Vector3 _touch = Vector3.one * 1000;
        [SerializeField] private float touchDistance = 10;

        public bool calculateTouch(Vector3 touch)
        {
            var distance = Vector3.Distance(_touch, touch);
            print(distance);
            return distance >= touchDistance;
        }
    }

}
