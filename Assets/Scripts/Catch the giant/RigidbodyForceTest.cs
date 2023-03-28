using UnityEngine;

namespace CatchTheGiant
{
    public class RigidbodyForceTest : MonoBehaviour
    {
        private Rigidbody rigid;
        [SerializeField] private float jumpForce = 100;

        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            rigid.AddForce(Vector3.up * jumpForce);
        }


    }

}
