using UnityEngine;

namespace ColorJump
{
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private Vector3[] indexPoint;
        int i;
        [SerializeField] private float speed = 1;

        private void Update()
        {
            if (transform.position == indexPoint[i])
            {
                if (i + 1 < indexPoint.Length)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, indexPoint[i], speed * Time.deltaTime);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            for (int i = 0; i < indexPoint.Length; i++)
            {
                Gizmos.DrawWireSphere(indexPoint[i], 0.1f);
            }


        }
    }
}
