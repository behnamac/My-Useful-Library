using UnityEngine;

namespace HottieLife
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 offset;
        [SerializeField] Transform target;
        [SerializeField] private float followSpeed;
        [SerializeField] private bool setCameraToPlayerSpeed;
        [SerializeField] bool xLockPos;
        Camera cam;


        private void Awake()
        {
            cam = Camera.main;
            offset = transform.position - target.position;

            if (setCameraToPlayerSpeed)
            {
                var speed = FindObjectOfType<PlayerMovement>().playerSpeed;
                followSpeed = speed;
            }
        }

        private void LateUpdate()
        {
            SmoothFollow();
        }

        private void SmoothFollow()
        {
            var totalOffset = offset + target.position;

            if (xLockPos)
            {
                totalOffset.x = transform.position.x;
            }
            transform.position = Vector3.Lerp(transform.position, totalOffset, followSpeed * Time.deltaTime);
        }

    }
}
