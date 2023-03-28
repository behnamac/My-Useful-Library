using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NursePower
{
    public class CollectAndShoot : MonoBehaviour
    {
        [HideInInspector] public bool canShoot;
        [HideInInspector] public List<Transform> ammuList;
        [SerializeField] private Transform ammuInventory;
        [SerializeField] private Transform ammuParentPoint;
        private int ammuValue;
        private float bulletspace = 0.3f;

        //--- object pooling ------
        public List<GameObject> bulletPool;
        private GameObject bulletPoolParent;
        [SerializeField] private Transform ShootPoint, shootPointTarget;
        [SerializeField] private Transform ammuModel;


        [SerializeField] private float shootTime = 0.3f;
        [SerializeField] private Vector3 checkerOffset;
        [SerializeField] private LayerMask targetlayer;
        [SerializeField] private float checkerSize = 5f;
        private float currentShootTime;
        private bool shootDetect;

        private float rotY;
        private float rotX;
        private bool postLevelShoot;

        [SerializeField] private float speedRot;
        [SerializeField] NPFixedTouchField joystick;
        [SerializeField] private float minYRot, maxYRot;
        [SerializeField] private float maxXRot, minXRot;
        [SerializeField] private Transform targetImg;



        Rigidbody rigid;

        private void Awake()
        {
            canShoot = true;
            rigid = GetComponent<Rigidbody>();

        }

        private void Start()
        {
            bulletPoolParent = new GameObject("Bullet pool Player");
            currentShootTime = shootTime;
            ammoFormation(ammuList.ToArray());
            postLevelShoot = false;
        }

        private void Update()
        {
            if (canShoot)
                destectshoot();

            if (postLevelShoot)
                PLShoot();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Ammu")
            {
                ammuValue++;
                var bulletBack = Instantiate(ammuInventory);
                ammuList.Add(bulletBack);
                ammoFormation(ammuList.ToArray());
                Destroy(other.gameObject);
            }
            else if (other.tag == "Obstcle")
            {
                fallAmmo(3);
            }
            else if (other.tag == "FinishLine")
            {
                PlayerController.canMove = false;
                PlayerController.canControl = false;
                StartCoroutine(GoToCenterCo());
                CameraController.Instance.cameraState = CameraState.postLevel;
                EnemyPostLevelSpawn.Instance.Spawn();
                postLevelShoot = true;
                canShoot = false;
                targetImg.gameObject.SetActive(true);
            }
        }

        private void ammoFormation(Transform[] obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].SetParent(transform);
                obj[i].transform.position = new Vector3(ammuParentPoint.position.x,
                    1f + (i * bulletspace), ammuParentPoint.transform.position.z);

                obj[i].transform.rotation = Quaternion.Euler(-90, 90, 0);
            }
        }

        #region shoot

        private void destectshoot()
        {
            RaycastHit hit;
            bool find = Physics.Raycast(transform.position + checkerOffset, transform.forward, out hit, checkerSize, targetlayer);
            if (find && ammuValue > 0)
            {
                if (!shootDetect)
                {
                    InvokeRepeating(nameof(shoot), 0, shootTime);
                    shootDetect = true;
                }
            }
            else
            {
                CancelInvoke(nameof(shoot));
                shootDetect = false;
            }


        }

        private void shoot()
        {
            for (int i = 0; i < bulletPool.Count; i++)
            {
                if (!bulletPool[i].activeInHierarchy)
                {
                    var b = bulletPool[i].transform;

                    if (postLevelShoot)
                    {
                        b.GetComponent<BulletController>().speed = 80;
                    }
                    b.transform.position = ShootPoint.position;
                    b.transform.rotation = ShootPoint.rotation;
                    b.gameObject.SetActive(true);
                    ammuValue--;
                    removeAmmo();
                    return;
                }
            }

            var bullet = Instantiate(ammuModel, ShootPoint.position, ShootPoint.rotation, bulletPoolParent.transform);

            if (postLevelShoot)
            {
                bullet.GetComponent<BulletController>().speed = 80;
            }

            bulletPool.Add(bullet.gameObject);
            ammuValue--;
            removeAmmo();
        }

       

        private void removeAmmo()
        {
            if (ammuList.Count <= 0) return;
            Destroy(ammuList[ammuList.Count - 1].gameObject);
            ammuList.RemoveAt(ammuList.Count - 1);
            ammoFormation(ammuList.ToArray());
        }

        private void fallAmmo(int value)
        {
            if (ammuList.Count > value)
            {
                rigid.velocity = -transform.forward * 6;
                PlayerController.canMove = false;
                Invoke(nameof(SetBoolMove), 1.2f);

            }
            else
            {
                print("lose!");
            }
        }


        #endregion

        #region PosLevelShoot

        private void PLShoot()
        {
            rotY += (joystick.TouchDist.y * speedRot) * Time.deltaTime;
            rotX += (joystick.TouchDist.x * speedRot) * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, minXRot, maxXRot);
            rotY = Mathf.Clamp(rotY, minYRot, maxYRot);
            ShootPoint.eulerAngles = new Vector3(-rotY, rotX, 0);
            Vector3 pos = Camera.main.WorldToScreenPoint(shootPointTarget.position);
            targetImg.position = pos;

            RaycastHit hit;
            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit, 100))
            {
                if (hit.collider.GetComponent<EnemyPostLevel>())
                {
                    if (!hit.collider.GetComponent<EnemyPostLevel>().hit)
                    {
                        currentShootTime -= Time.deltaTime;
                        if (currentShootTime<=0)
                        {
                            currentShootTime = shootTime;
                            shoot();
                        }
                    }
                }
            }


        }

        #endregion

        private void SetBoolMove()
        {
            PlayerController.canMove = true;
        }

        IEnumerator GoToCenterCo()
        {
            while (transform.position.x != 0)
            {
                yield return new WaitForEndOfFrame();
                Vector3 vec = new Vector3(0, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, vec, 5f * Time.deltaTime);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position + checkerOffset, transform.forward * checkerSize);
        }



    }
}
