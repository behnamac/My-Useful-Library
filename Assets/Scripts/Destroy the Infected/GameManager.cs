using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DestroyTheInfected
{
    public enum GameState { Start, InGame, Win, Lose }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public delegate void OnLevelStartHandler();
        public delegate void OnLevelCompleteHandler();
        public delegate void OnLevelFailHandler();

        public static event OnLevelStartHandler OnLevelStart;
        public static event OnLevelCompleteHandler OnLevelComplete;
        public static event OnLevelFailHandler OnLevelFail;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }


        public void LevelComplete()
        {
            OnLevelComplete?.Invoke();
        }

        public void LevelFail()
        {
            OnLevelFail?.Invoke();
        }

        public void LevelStart()
        {
            OnLevelStart?.Invoke();
        }


    }
}
