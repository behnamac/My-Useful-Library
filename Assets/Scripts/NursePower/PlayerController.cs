using UnityEngine;

namespace NursePower
{
    public class PlayerController : MonoBehaviour
    {
        public static bool canControl = true;
        public static bool canMove = true;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float horizontalSpeed = 3f;
        [SerializeField] private float maxHorizontal = 4.5f;
        private float firstPos;
        private float deltaSwipe;

        private void Awake()
        {
         //   Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (canMove)
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (canControl)
                horizontalMovement();

        }

        private void horizontalMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                deltaSwipe = Input.mousePosition.x - firstPos;
                firstPos = Input.mousePosition.x;
            }
            if (Input.GetMouseButtonUp(0))
            {
                deltaSwipe = 0;
            }

            transform.position = calculateHorizontalMovement(transform.position, deltaSwipe);
        }

        private Vector3 calculateHorizontalMovement(Vector3 pos, float delta)
        {
            delta *= horizontalSpeed * Time.deltaTime;
            var clamp = Mathf.Clamp(delta + pos.x, -maxHorizontal, maxHorizontal);
            pos = new Vector3(clamp, pos.y, pos.z);
            return pos;

        }
    }
}

