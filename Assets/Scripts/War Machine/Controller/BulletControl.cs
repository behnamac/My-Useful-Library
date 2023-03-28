using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class BulletControl : MonoBehaviour
    {
        public string[] targetTags { get; set; }

        public float damage { get; set; }


        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Bullet"))
            {
                bool _find = false;
                for (int i = 0; i < targetTags.Length; i++)
                {
                    if (other.gameObject.CompareTag(targetTags[i]))
                    {
                        _find = true;
                    }
                }
                if (!_find) return;

                var target = other.GetComponent<HealthControl>();
                target.SetHealth(damage);
                Deactive();
            }
        }

        private void Deactive()
        {
            gameObject.SetActive(false);
        }
    }
}
