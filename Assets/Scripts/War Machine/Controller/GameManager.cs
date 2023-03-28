using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public delegate void LevelStartHandler();
        public delegate void LevelCompleteHandler();
        public delegate void LevelFaildHandler();
        public delegate void LevelLoadHandler();

        public static event LevelStartHandler OnLevelStart;
        public static event LevelCompleteHandler OnLevelComplete;
        public static event LevelFaildHandler OnLevelFaild;
        public static event LevelLoadHandler OnLevelLoad;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void LevelStart()
        {
            OnLevelStart?.Invoke();
        }

        public void LevelComplete()
        {
            OnLevelComplete?.Invoke();
        }

        public void LevelFailed()
        {
            OnLevelFaild?.Invoke();
        }

        public void LevelLoad()
        {
            OnLevelLoad?.Invoke();
        }

       

    }

}
