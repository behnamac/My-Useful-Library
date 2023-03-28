using UnityEngine;

namespace HottieLife
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool canControl;
        public float playerSpeed = 5f;
        float _deltaSwip;
        float _mouseXStartPosition;
        [SerializeField] private float horizontalSpeed = 5f;
        public float MaxHorizontalMove = 4.5f;


        private void Awake()
        {
            canControl = true;
        }

        void Update()
        {
            Movement();
            HorizontalController();
        }

        void Movement()
        {
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }

        void HorizontalController()
        {
            if (!canControl) return;

            if (Input.GetMouseButtonDown(0))

                _mouseXStartPosition = Input.mousePosition.x;

            if (Input.GetMouseButton(0))
            {
                _deltaSwip = Input.mousePosition.x - _mouseXStartPosition;

                _mouseXStartPosition = Input.mousePosition.x;
            }
            transform.position = CalculateHorizontal(_deltaSwip, transform.position);

            if (Input.GetMouseButtonUp(0))
            {
                _deltaSwip = 0;
            }


        }

        Vector3 CalculateHorizontal(float delta, Vector3 pos)
        {
            delta *= horizontalSpeed * Time.deltaTime;
            var clamp = Mathf.Clamp(delta + pos.x, -MaxHorizontalMove, MaxHorizontalMove);
            // pos.x += delta;
            pos = new Vector3(clamp, pos.y, pos.z);
            return pos;
        }
    }
}
