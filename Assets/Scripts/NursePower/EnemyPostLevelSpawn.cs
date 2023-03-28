using UnityEngine;

namespace NursePower
{
    public class EnemyPostLevelSpawn : MonoBehaviour
    {
        public static EnemyPostLevelSpawn Instance;
        [SerializeField] private EnemyPostLevel enemyPostLevel;
        [SerializeField] private Transform[] spawnPoint;
        [SerializeField] private float spawnTime;
        public int NumberOfHitEnemy = 2;

        private void Awake()
        {
            Instance = this;
        }

        public void Spawn()
        {
            InvokeRepeating(nameof(spawn), 0, spawnTime);
        }

        private void spawn()
        {
            var random = Random.Range(0, spawnPoint.Length);
            float _offset = 1.5f;
            Vector3 pos = new Vector3(spawnPoint[random].position.x, spawnPoint[random].position.y + _offset, spawnPoint[random].position.z);
            var clone = Instantiate(enemyPostLevel, pos, spawnPoint[random].localRotation);

            if (spawnPoint[random].position.x > 0)
            {
                clone.SpeedMove *= -1;
            }
        }
    }
}
