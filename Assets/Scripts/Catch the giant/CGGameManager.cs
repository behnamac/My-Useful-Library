using UnityEngine;

namespace CatchTheGiant
{
    public class CGGameManager : MonoBehaviour
    {
        public static CGGameManager Instance;

        public delegate void OnLevelWinHandler();
        public delegate void OnLevelLoseHandler();

        public static event OnLevelWinHandler LevelWin;
        public static event OnLevelLoseHandler LevelLose;




        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        public void LoseState()
        {
            LevelLose?.Invoke();

        }

        public void WinState()
        {
            LevelWin?.Invoke();
        }
    }
}
