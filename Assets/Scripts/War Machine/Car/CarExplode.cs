using UnityEngine;

namespace WarMachine
{
    public class CarExplode : MonoBehaviour
    {
        private HealthControl _healthControl;

        private void Awake()
        {
            TryGetComponent(out _healthControl);
            _healthControl.OnDead += Explosion;
        }

        public void Explosion()
        {
            var rigidbody = GetComponent<Rigidbody>();
            var particle = ParticleManager.PlayParticle("Explosion", transform.position + Vector3.up * 1.9f, Quaternion.identity);
            Destroy(particle.gameObject, 2f);
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            rigidbody.velocity = new Vector3(Random.Range(-3, 3), Random.Range(10, 20), Random.Range(0, 5));
            rigidbody.angularVelocity = new Vector3(0, 0, Random.Range(-10, 10));

        }

        private void OnDestroy()
        {
            _healthControl.OnDead -= Explosion;

        }
    }
}
