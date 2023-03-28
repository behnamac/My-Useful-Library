using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class ObjectPooling : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform SpawnPoint;
        [SerializeField] private int poolSize = 10;
        private Queue<Bullet> _pool;

        private Transform _bulletParent;

        private void Awake()
        {
            _bulletParent = new GameObject("bulletParent").transform;
            _pool = new Queue<Bullet>(poolSize);

            for (int i = 0; i < poolSize; i++)
            {
                Bullet obj = Instantiate(bulletPrefab,SpawnPoint.position,Quaternion.identity, _bulletParent);
                obj.pool = this ;
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }     

       
        private Bullet GetBullet()
        {

            if (_pool.Count == 0)
            {
                // If the pool is empty, instantiate a new object
                Bullet obj = Instantiate(bulletPrefab, SpawnPoint.position, Quaternion.identity, _bulletParent);
                obj.pool=this;
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }

            Bullet result = _pool.Dequeue();
            result.transform.position = SpawnPoint.position;
            result.gameObject.SetActive(true);
            return result;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetBullet();
            }

        }

        // Function to return an object to the pool
        public void ReturnObject(Bullet obj)
        {
            _pool.Enqueue(obj);

        }



    }
}
