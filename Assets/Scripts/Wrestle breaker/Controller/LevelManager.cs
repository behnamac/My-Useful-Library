using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WrestleBreaker
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        public static UnityAction<Level> OnLevelStart;
        public static UnityAction<Level> OnLevelComplete;
        public static UnityAction<Level> OnLevelFail;
        public static UnityAction<Level> OnLoadLevel;

        [SerializeField] private LevelSource levelSource;
        [SerializeField] private Transform levelSpawnPoint;

        [SerializeField] private bool loop;
        [ConditionalHide(nameof(loop), true)]
        [SerializeField] private int loopLevelStartIndex = 1;

        #region Custom Methodes

        public GameObject GetCurrentLevel()
        {
            if (PlayerPrefsController.GetLevelIndex() >= levelSource.Levels.Length && loop)
            {
                var levelIndex = Random.Range(loopLevelStartIndex, levelSource.Levels.Length);
                PlayerPrefsController.SetLevelIndex(levelIndex);
            }

            GameObject level = levelSource.Levels[PlayerPrefsController.GetLevelIndex()];
            return level;
        }

        public void LoadlLevel()
        {
            Instantiate(GetCurrentLevel(), levelSpawnPoint);
            var currentLevel = GetCurrentLevel().GetComponent<Level>();
            WaveHolder.CurrentLevel=currentLevel;
            OnLoadLevel?.Invoke(currentLevel);
        }

        private void CheckRepeatLevel()
        {
            //for preserve a bug
            if (loopLevelStartIndex < levelSource.Levels.Length) return;

            loopLevelStartIndex = 0;

        }
        #endregion

        #region Action Methodes

        public void LevelStart()
        {
            OnLevelStart?.Invoke(GetCurrentLevel().GetComponent<Level>());
        }


        public void LevelComplete()
        {
            var Index = PlayerPrefsController.GetLevelIndex();
            PlayerPrefsController.SetLevelIndex(Index + 1);
            PlayerPrefsController.SetLevelNumber(Index + 1);
            OnLevelComplete?.Invoke(GetCurrentLevel().GetComponent<Level>());
        }


        public void LevelFail()
        {
            OnLevelFail?.Invoke(GetCurrentLevel().GetComponent<Level>());
        }
        #endregion

        #region Unity Methodes

        private void Awake()
        {

            if (!Instance)
                Instance = this;
            else
                Destroy(this);

            CheckRepeatLevel();
        }

        private void Start() => LoadlLevel();

        #endregion

    }

}
