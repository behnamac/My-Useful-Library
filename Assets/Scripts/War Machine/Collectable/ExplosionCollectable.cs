using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class ExplosionCollectable : MonoBehaviour
    {
        private HealthControl _healthControl;
        private Transform _player;
//        [SerializeField] private float minRange = 4f;
//        [SerializeField] private float maxRange = 30f;

        private float _damage=2f;
        private bool _find;
        private bool _destroy;

        private void Awake()
        {
            _healthControl = GetComponent<HealthControl>();
          _player = FindObjectOfType<PlayerMove>().transform;
        }
        private void Update()
        {
           // CheckPos();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag=="Bullet")
            {
                _healthControl.SetHealth(_damage);
                if (_healthControl.GetHealth()<=0)
                {
                    DestroyObject();
                }
            }
        }

        //private void CheckPos()
        //{
        //    if (Vector3.Distance(transform.position, _player.transform.position) <= maxRange && !_find)
        //    {
        //        _player.GetComponent<PlayerMove>().Enemiesfound.Add(transform);
        //        _find = true;
        //    }
        //    else if (Vector3.Distance(transform.position, _player.transform.position) <= minRange&& !_destroy)
        //    {
        //        DestroyObject();
        //        _player.GetComponent<HealthControl>().SetHealth(_damage);
        //        _destroy = true;
                
        //    }
        //}

        private void DestroyObject()
        {
            ParticleManager.PlayParticle("Explosion",transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireSphere(transform.position, maxRange);
        //    Gizmos.DrawSphere(transform.position, minRange);
        //}
    }
}
