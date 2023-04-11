using Levels;
using Storage;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class LevelManager : MonoBehaviour
    {
        #region DELEGATE

        public delegate void LevelInitializeHandler(Level levelData);

        public delegate void LevelLoadHandler(Level levelData);

        public delegate void LevelStartHandler(Level levelData);

        public delegate void LevelCompleteHandler(Level levelData);

        public delegate void LevelFailHandler(Level levelData);

        public delegate void LevelUpdateHandler(Level levelData);

        public delegate void LevelFixedUpdateHandler(Level levelData);

        //  public delegate void Test(float f);

        public static UnityAction<float> Test;

        #endregion

        #region EVENTS

        public static LevelLoadHandler OnLevelLoad;


        /// <summary>
        ///     Event that runs after the level is loaded and indicates that the level is loaded.
        /// </summary>
        public static LevelLoadHandler OnLevelInintialize;

        /// <summary>
        /// The event that runs when you start playing the level.
        /// </summary>
        public static LevelStartHandler OnLevelStart;

        /// <summary>
        /// Event running when level is completed
        /// </summary>
        public static LevelCompleteHandler OnLevelComplete;

        /// <summary>
        /// Event running when level fails
        /// </summary>
        public static LevelFailHandler OnLevelFail;

        /// <summary>
        /// Event running during level base per frame(for physics)
        /// </summary>
        public static LevelFixedUpdateHandler OnLevelFixedUpdate;

        /// <summary>
        /// Event running during level base per frame
        /// </summary>
        public static LevelUpdateHandler OnLevelUpdate;

        //public static Test TestHandler;

        #endregion

        #region PUBLIC FIELDS / PROPS

        public static LevelManager Instance { get; private set; }

        #endregion

        #region SERIALIZE PRIVATE FIELDS

        // Source of levels
        [SerializeField] private LevelSource levelSource;

        // The container where the level will be spawned
        [SerializeField] private GameObject levelSpawnPoint;

        // It determines from which level it will start when it returns to the beginning after the maximum level. The default value is 1. 
        [SerializeField] private int loopLevelsStartIndex = 1;

        // It determines whether the levels to be loaded after the maximum level will come randomly or not, the default value is True.
        [SerializeField] private bool loopLevelGetRandom = true;

        #endregion

        #region PRIVATE FIELDS

        private GameObject _activeLevel;

        #endregion

        #region PRIVATE METHODS

        private void CheckRepeatLevelIndex()
        {
            if (loopLevelsStartIndex < levelSource.levelData.Length) return;
            loopLevelsStartIndex = 0;
        }

        private GameObject GetLevel()
        {
            if (PlayerPrefsController.GetLevelIndex() >= levelSource.levelData.Length)
            {
                if (loopLevelGetRandom)
                {
                    var levelIndex = Random.Range(loopLevelsStartIndex, levelSource.levelData.Length - 1);
                    PlayerPrefsController.SetLevelIndex(levelIndex);
                }
            }

            var level = levelSource.levelData[PlayerPrefsController.GetLevelIndex()];

            var levelData = level.GetComponent<Level>();

            return level;
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        ///     Method that loads the next level
        /// </summary>
        public void LevelInitialize()
        {
            OnLevelInintialize?.Invoke(_activeLevel.GetComponent<Level>());
        }

        /// <summary>
        ///     Method that loads the next level
        /// </summary>
        public void LevelLoad()
        {
            _activeLevel = Instantiate(GetLevel(), levelSpawnPoint.transform, false);
            OnLevelLoad?.Invoke(_activeLevel.GetComponent<Level>());
        }

        /// <summary>
        ///     The method that starts the last loaded level
        /// </summary>
        public void LevelStart()
        {
            OnLevelStart?.Invoke(_activeLevel.GetComponent<Level>());
            Test?.Invoke(2);
        }


        /// <summary>
        ///     The method that will be called when the level played is completeds
        /// </summary>
        public void LevelComplete()
        {
            // Sonraki level index değeri atanıyor
            PlayerPrefsController.SetLevelIndex(PlayerPrefsController.GetLevelIndex() + 1);

            // Sonraki level numarası atanıyor
            PlayerPrefsController.SetLevelNumber(PlayerPrefsController.GetLevelNumber() + 1);


            OnLevelComplete?.Invoke(_activeLevel.GetComponent<Level>());
        }

        /// <summary>
        ///     The method that will be called when the level played is unsuccessful
        /// </summary>
        public void LevelFail()
        {
            OnLevelFail?.Invoke(_activeLevel.GetComponent<Level>());
        }

        public void LevelFixedUpdate()
        {
            OnLevelFixedUpdate?.Invoke(_activeLevel.GetComponent<Level>());

        }

        public void LevelUpdate()
        {
            OnLevelUpdate?.Invoke(_activeLevel.GetComponent<Level>());

        }

        #endregion

        #region UNITY EVENT METHODS

        private void Awake()
        {
            CheckRepeatLevelIndex();
            Instance = this;
            LevelInitialize();
        }

        private void Start() => LevelLoad();

        private void Update() => LevelUpdate();

        private void FixedUpdate() => LevelFixedUpdate();


        #endregion
    }
}