using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Vector3 speed;
        public ObjectPooling pool { get; set; }

        //public Bullet(ObjectPooling pool)
        //{
        //    this.pool = pool;
        //}

        private void Update()
        {
            transform.position += speed * Time.deltaTime;
        }
        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            pool.ReturnObject(this);
        }



    }
}
