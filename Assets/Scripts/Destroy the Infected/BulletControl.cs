using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyTheInfected
{
    public class BulletControl : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int damage;
        [SerializeField] private float destroyTime=1.5f;

        private void Update()
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Invoke(nameof(Deactive), destroyTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag== "Enemy")
            {
                other.GetComponent<NPCController>().Damage(damage);
                gameObject.SetActive(false);
            }
            
        }

        private void Deactive()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Deactive));
        }

    }
}
