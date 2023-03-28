using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Fundamental
{
    public class ObjectPoolingOldVersion : MonoBehaviour
    {
        [SerializeField] private GameObject bulletObj;
        [SerializeField] private List<Transform> bulletList;
        [SerializeField] private Transform shootPoint;
        private GameObject _parentBullet;


        private void Awake()
        {
            _parentBullet = new GameObject("Bullet Parent");
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                ShootType1();

        }


        private void ShootType1()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].gameObject.activeInHierarchy)
                {
                    var _bullet = bulletList[i];
                    _bullet.transform.position = shootPoint.transform.position;
                    _bullet.transform.rotation = shootPoint.transform.rotation;
                    _bullet.gameObject.SetActive(true);
                    return;
                }
            }

            var bullet = Instantiate(bulletObj, shootPoint.position, shootPoint.rotation, _parentBullet.transform);
            bulletList.Add(bullet.transform);
        }


       
    }
}
