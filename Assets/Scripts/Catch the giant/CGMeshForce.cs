using UnityEngine;

namespace CatchTheGiant
{
    public class CGMeshForce : MonoBehaviour
    {
        [SerializeField] private float force = 200f;
        [SerializeField] private Transform[] objectToForce;

        public CGEnenmyController giant;

        private void Awake()
        {
            giant = GetComponentInParent<CGEnenmyController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Respawn"))
            {
                foreach (var item in objectToForce)
                {

                    item.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
                    item.GetComponent<Rigidbody>().useGravity = true;
                    item.GetComponent<Rigidbody>().isKinematic = false;

                    //item.transform.SetParent(null);
                    giant.death(1.5f);
                }
            }
        }
    }
}
