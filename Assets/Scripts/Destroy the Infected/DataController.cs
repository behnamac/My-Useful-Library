using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyTheInfected
{
    public class DataController : MonoBehaviour
    {
        public static DataController Instance;
        public CollectableController collectable;

        private void Awake()
        {
            if(Instance==null)
                Instance = this;
        }
    }

}
