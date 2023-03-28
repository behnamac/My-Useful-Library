using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace WarMachine
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance;
        [SerializeField] private SplineComputer splineComputer;
        [SerializeField] private SplineFollower SpawnPoint;
        // [SerializeField] private EnemyProperties enemies;

        [SerializeField] private List<EnenmyList> waves;
        [SerializeField] private float spawnEnemyTime;
        [SerializeField] private List<Transform> Currentenemies;
        private float _firstWaveCount;

        [SerializeField] private Transform finishLine;

        public int numberOfEnemy { get; private set; }
        private int waveEnemy;

        int number;

        #region Custom Methodes

        private void spawnEnemy()
        {
            for (int i = 0; i < waves[0].enemies.Length; i++)
            {
                var _enemy = Instantiate(waves[0].enemies[i].EnemyObj,SpawnPoint.transform);
                var _enemyComponent = _enemy.GetComponent<EnemyMove>();
                _enemyComponent.CanChangeLine = waves[0].enemies[i].CanChangeLine;
                _enemy.transform.localPosition = new Vector3(0, 0, waves[0].enemies[i].SpawnPoint.z);
                _enemy.transform.SetParent(null);
                //convert 3d vector to 2d vector
                _enemy.motion.offset = (Vector2)waves[0].enemies[i].SpawnPoint;
                _enemyComponent.DistanceToPlayer = waves[0].enemies[i].SpawnPoint.z;
                _enemyComponent.FirstLine = waves[0].enemies[i].FirstLine;
                _enemyComponent.TargetLine = waves[0].enemies[i].TargetLine;
                _enemyComponent.Spline.followSpeed = _enemyComponent.FollowSpeed;
                _enemy.spline = splineComputer;
                Currentenemies.Add(_enemy.transform);               

            }
        }

        public void RemoveEnemy(EnemyMove enemy)
        {
            Currentenemies.Remove(enemy.transform);
            if (Currentenemies.Count <= 0)
                SetEnemy();
        }


        private void Initialized()
        {
            SpawnPoint.followSpeed = 0;
            _firstWaveCount = waves.Count;
        }

        #endregion 


        #region Unity Methodes

        private void Awake()
        {
            Instance = this;
            Initialized();

            for (int i = 0; i < waves.Count; i++)
            {
                for (int j = 0; j < waves[i].enemies.Length; j++)
                {
                    numberOfEnemy++;
                }
            }
        }

        
        private void OnEnable()
        {
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFaild += OnLevelFaild;
            GameManager.OnLevelStart += OnLevelStart;
        }

        private void OnDisable()
        {
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFaild -= OnLevelFaild;
            GameManager.OnLevelStart -= OnLevelStart;

        }
        #endregion

        #region Delegate Methodes

        private void OnLevelComplete()
        {

        }
        private void OnLevelFaild()
        {

        }
        private void OnLevelStart()
        {
           Invoke(nameof(spawnEnemy), 0.1f);
        }

        public void SetEnemy()
        {
            if (Currentenemies.Count <= 0)            
                waves.RemoveAt(0);
                if (waves.Count > 0)
                {
                    Invoke(nameof(spawnEnemy), spawnEnemyTime);
                }
                else
                {
                    print("finish");
                    finishLine.gameObject.SetActive(true);
                    finishLine.transform.SetParent(null);
                }

            
            UIManager.Instance.Progressbar(Mathf.Abs((waves.Count / _firstWaveCount) - 1));
        }



        #endregion



    }

    [System.Serializable]
    public class EnenmyList
    {
        [SerializeField] private string waveNumber;

        public EnemyProperties[] enemies;
    }

    [System.Serializable]
    public class EnemyProperties
    {
        [SerializeField] private string EnemyNum;

        public SplineFollower EnemyObj;
        public Vector3 SpawnPoint;
        public bool CanChangeLine;
        [ConditionalHide("CanChangeLine", true)]
        public Vector2 TargetLine;
        public Vector2 FirstLine;
    }

}


