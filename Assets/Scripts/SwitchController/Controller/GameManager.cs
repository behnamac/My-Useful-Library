using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace switchCotroller
{
    public enum State
    {
        Menu,
        TopDown,
        ThirdPerson
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public State GameState = State.Menu;
        public static UnityAction OnLevelStart;
        public static UnityAction OnLevelComplete;
        public static UnityAction OnLevelFailed;


        private void Awake()
        {
            if (!Instance) Instance = this;
        }

        public void OnStart()
        {
            OnLevelStart?.Invoke();
        }

        public void LevelComplete()
        {
            OnLevelComplete?.Invoke();
        }

        public void LevelFailed()
        {
            OnLevelFailed?.Invoke();
        }

    }

}
