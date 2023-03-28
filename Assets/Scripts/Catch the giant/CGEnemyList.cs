using System.Collections.Generic;
using UnityEngine;

namespace CatchTheGiant
{
    public class CGEnemyList : MonoBehaviour
    {
        public static CGEnemyList Instance;

        [HideInInspector] public List<CGEnenmyController> enemyList = new List<CGEnenmyController>();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            enemyList.AddRange(FindObjectsOfType<CGEnenmyController>());
        }
    }
}
