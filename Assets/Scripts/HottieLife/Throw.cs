using UnityEngine;

namespace HottieLife
{
    public class Throw : MonoBehaviour
    {
        public GameObject target;
        public Transform shootPoint;
        public Rigidbody obj;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 velocity = calculateVelocity(new Vector3(target.transform.position.x, target.transform.position.y + 5, target.transform.position.z), shootPoint.position, 1);
                var model = Instantiate(obj, shootPoint.position, Quaternion.identity);
                model.velocity = velocity;
            }
        }

        private Vector3 calculateVelocity(Vector3 target, Vector3 orgin, float time)
        {
            Vector3 distance = target - orgin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0;

            float SY = distance.y;
            float SXY = distanceXZ.magnitude;

            float Vy = SY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;
            float Vxz = SXY / time;
            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;

            return result;

        }
    }
}
