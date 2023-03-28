using UnityEngine;

namespace NursePower
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float destroyTime;
        public float speed = 40;

        private void OnEnable()
        {
            Invoke(nameof(Destroy), destroyTime);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
        private void Update()
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }

    }
}
