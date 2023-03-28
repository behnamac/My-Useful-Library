using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyTheInfected
{

    [CreateAssetMenu(menuName = "Data/Destroy the Infected/data")]

    public class CollectableController : ScriptableObject
    {
        [Header("Coin")]
        public int CoinValue=1;
        public int TotalCoin;

        [Header("Player")]
        public int CollectablerHealthValue = 1;
        public float PlayerMaxHealth=100;
        [HideInInspector] public float PlayerCurrentHealth;

        [Header("Enemy")]
        public int KilledEnemy;
        public int EnemyMaxHealth=3;
        [HideInInspector] public int EnemyCurrentHealth;


    }

}
