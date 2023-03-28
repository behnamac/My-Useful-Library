using System.Collections;
using UnityEngine;

namespace HottieLife
{
    public class NPCThrower : MonoBehaviour
    {
        [SerializeField] Vector3 triggerCenter;
        [SerializeField] Vector3 triggerSize;
        [SerializeField] LayerMask layerMask;
        private Vector3 newCenter;
        bool isTrigger;
        Vector3 target;

        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;

        }

        void Update()
        {
            checkCollide();
        }

        void checkCollide()
        {
            newCenter = transform.position + triggerCenter;
            Collider[] col = Physics.OverlapBox(newCenter, triggerSize);

            if (Physics.CheckBox(newCenter, triggerSize) && !isTrigger)
            {
                isTrigger = true;
                //StartCoroutine(lookAt(target));
                print("fg");
            }
        }

        IEnumerator lookAt(Vector3 target)
        {
            while (true)
            {
                var dir = target - transform.position;
                yield return new WaitForEndOfFrame();
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.6f);

            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            newCenter = transform.position + triggerCenter;

            Gizmos.DrawWireCube(newCenter, triggerSize);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<PlayerMovement>())
            {
                if (Input.GetMouseButton(0))
                {
                    print("touch");
                }
            }
        }
    }
}
