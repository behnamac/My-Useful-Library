using UnityEngine;

namespace NursePower
{
    public class EnemyPostLevel : MonoBehaviour
    {
        public float speedRun = 5, SpeedMove = 5;
        [SerializeField] private SkinnedMeshRenderer skinnedMesh;
        [HideInInspector] public bool hit;

        private void Start()
        {
            Destroy(gameObject, 20);
        }

        private void Update()
        {
            if (!hit)
            {
                transform.Translate(SpeedMove * Time.deltaTime, 0, 0);

            }
            else
            {
                transform.Translate(0, -speedRun * Time.deltaTime, 0);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BulletController>())
            {
                damage();
            }
        }

        private void damage()
        {

            hit = true;
            skinnedMesh.SetBlendShapeWeight(0, 0);
        }
    }
}
