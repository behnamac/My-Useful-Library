using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class ExplosionForce : MonoBehaviour
    {

        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float radius;
        [SerializeField] private float force;
        private Collider[] _colliders;

        public void Expload()
        {
            _colliders = Physics.OverlapSphere(transform.position, radius, targetLayer);

            for (int i = 0; i < _colliders.Length; i++)
            {
                Rigidbody _rigidbody = _colliders[i].GetComponent<Rigidbody>();
                _rigidbody.AddExplosionForce(force, transform.position, radius);
            }
            print("explode");
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

    }
}
