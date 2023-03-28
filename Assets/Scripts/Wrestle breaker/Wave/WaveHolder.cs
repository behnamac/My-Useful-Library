using System;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    public enum WrestelMode
    {
        Idle,
        Walk,
        Wrestle,
        dead
    }

    public class WaveHolder : MonoBehaviour
    {
        public static WaveHolder Instance;

        public WrestelMode GameMode = WrestelMode.Wrestle;

        public static Level CurrentLevel;
        [HideInInspector] public List<Enemy> enemieList;

        [SerializeField] private Enemy EnemyModel;
        [SerializeField] private Transform spawnPoint;

        private GameObject _enemieParent;
        private float _currentEnemyPower;

        private float _score;
        public float Score
        {
            get
            {
                _score = PlayerPrefsController.GetScore();
                return _score;
            }
            set
            {
                _score = CurrentLevel.WaveInfo.score;
            }
        }

        public List<float> _enemyPowers;

        #region Unity Methodes
        private void Awake()
        {
            if (!Instance) Instance = this;
            enemieList = new List<Enemy>();
            _enemieParent = new GameObject("Enemy Parent");
           _enemyPowers = new List<float>();
        }

        private void OnEnable()
        {
            LevelManager.OnLoadLevel += OnLoadLevel;
        }
        protected void OnDisable()
        {
            LevelManager.OnLoadLevel -= OnLoadLevel;
        }

        private void OnLoadLevel(Level level)
        {
            Invoke(nameof(CreateEnemy), 0.3f);
        }


        #endregion

        #region Custom Methodes

        public int GetMaxEnemy()
        {
            var enemyCount = CurrentLevel.WaveInfo.maxEnemy;
            return enemyCount;
        }

        public static int GetMaxSliderDivide()
        {
            var sliderDivid = CurrentLevel.WaveInfo.StaminaBarDev;
            return sliderDivid;
        }

        public  float EnemyPower()
        {
            var firstEnemyPower = CurrentLevel.WaveInfo.EnemyPower;
            float ratio = 0.2f;
            _currentEnemyPower += firstEnemyPower + ratio;
            return _currentEnemyPower;
        }

        private void CreateEnemy()
        {
            var maxEnemy = GetMaxEnemy();
            float offset = -3;
            for (int i = 0; i < maxEnemy; i++)
            {
                var pos = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z + (i * offset));
                var enemy = Instantiate(EnemyModel, pos, spawnPoint.rotation, _enemieParent.transform);
                enemieList.Add(enemy);
                _enemyPowers.Add(EnemyPower());
            }
        }

        public void RemoveEnemy()
        {
            SetWrestelMode(WrestelMode.Walk);
            enemieList[0].GetComponent<Wreslers>().Death();
            enemieList.RemoveAt(0);
            _enemyPowers.RemoveAt(0);
            UIManager.Instance.SetCoin(_score);
            CheckWave();
            
        }


        private void CheckWave()
        {
            if (enemieList.Count <= 0)
            {
                LevelManager.Instance.LevelComplete();
                GameMode = WrestelMode.Idle;
            }
        }

        public WrestelMode SetWrestelMode(WrestelMode mode)
        {
            GameMode = mode;
            return GameMode;
        }

    }

    #endregion
}
