using UnityEngine;

namespace CatchTheGiant
{
    public class CGCameraController : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] private float cameraSpeed = 4f;
        private bool canMove = true;

        void Awake()
        {
            CGGameManager.LevelWin += LevelWinOrLose;
            CGGameManager.LevelLose += LevelWinOrLose;

        }

        void LateUpdate()
        {
            if (!canMove) return;
            transform.position = Vector3.Lerp(transform.position, target.position, cameraSpeed);

        }

        private void LevelWinOrLose()
        {
            canMove = false;
        }
    }
}
