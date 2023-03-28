using UnityEngine;

namespace WrestleBreaker
{
    [CreateAssetMenu(menuName ="Data/WrestelBreaker/WaveInfo",order =1)]
    public class WaveInfo : ScriptableObject
    {
        public int maxEnemy;
        public int StaminaBarDev;
        public float EnemyPower=3;
        public float score = 5;

    }
}
