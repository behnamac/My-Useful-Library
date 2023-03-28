using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class CarShoot : MonoBehaviour
    {

        public HealthControl target;
        public bool CanShoot { get; set; }

        public float damageBullet = -5;
        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private BulletControl bulletObj;
        [SerializeField] private string[] targetTags;

        [SerializeField] private Transform gunModel;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float shootTime = 0.3f;

        private List<BulletControl> _bulletPool;
        private Transform _bulletParent;

        private float _rotationSpeed = 8f;
        private float _currentShoot;




        #region Unity Methods          

        private void Awake()
        {
            Initialized();

        }


        private void Update()
        {
            if (target && CanShoot)
            {
                RotateGun();
                shoot();
            }
        }


        #endregion


        #region Custom Methods

        private void RotateGun()
        {
            Vector3 _shootDirection = target.transform.position - gunModel.position;
            _shootDirection.y = 0;
            gunModel.rotation = Quaternion.Slerp(gunModel.rotation, Quaternion.LookRotation(_shootDirection), _rotationSpeed * Time.deltaTime);
        }


        private void shoot()
        {
            _currentShoot -= Time.deltaTime;
            if (_currentShoot > 0) return;

            _currentShoot = shootTime;
            Vector3 _direction = target.transform.position;
            shootPoint.LookAt(_direction);

            for (int i = 0; i < _bulletPool.Count; i++)
            {
                if (!_bulletPool[i].gameObject.activeInHierarchy)
                {
                    var _bullet = _bulletPool[i];
                    var _bulletRigid = _bullet.GetComponent<Rigidbody>();
                    var _bulletTransform = _bullet.transform;
                    _bulletTransform.position = shootPoint.position;
                    _bulletTransform.rotation = shootPoint.rotation;
                    _bullet.gameObject.SetActive(true);
                    _bulletRigid.velocity = shootPoint.forward * bulletSpeed;
                    return;
                }
            }
            var bullet = Instantiate(bulletObj, shootPoint.position, shootPoint.rotation, _bulletParent);
            var bulletRigid = bullet.GetComponent<Rigidbody>();

            bullet.damage = damageBullet;
            bullet.targetTags = targetTags;
            bulletRigid.velocity = shootPoint.forward * bulletSpeed;
            _bulletPool.Add(bullet);

        }

        public void UpgradeBulletDamage(float value)
        {
            damageBullet += value;

        }

        private void Initialized()
        {
            _bulletPool = new List<BulletControl>();
            _bulletParent = new GameObject("Bullet Parent").transform;

            var checker = GetComponentInChildren<TargetChecker>();
            if (checker)
            {
                checker.carShoot = this;

            }
            CanShoot = true;

        }



        #endregion




    }
}

