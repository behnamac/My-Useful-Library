using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace DestroyTheInfected
{

    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance;
        [SerializeField] private SplineFollower spline;
        private SplineComputer splineComputer;

        [SerializeField] private CollectableController collectable;

        [Header("Movement")]
        [Space(5)]
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float maxHorizontal;
        private float currentSpeed;
        private bool canMove;
        private float _mouseXStartPos;
        private float _swipDelta;
        private float xMove;



        [Header("Health")]
        [Space(5)]
        private float currentHelath;
        private bool _death;


        [Header("Shoot")]
        [Space(5)]
        [SerializeField] private float shoorDistance;
        [SerializeField] private float shootTime = 0.3f;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Transform bulletPrefab;
        private GameObject _bulletParent;
        private List<Transform> _bulletList;
        private float _currentShootTime;





        #region Unity Methodes

        private void OnEnable()
        {
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFail += OnLevelFail;
            GameManager.OnLevelStart += OnLevelStart;
        }


        private void Awake()
        {
            Instance = this;
            spline = GetComponent<SplineFollower>();
            spline.followSpeed = 0;

        }

        private void Start()
        {
            UiController.Instance.healthBar.fillAmount = currentHelath;

            currentSpeed = maxSpeed;

            _bulletParent = new GameObject("Bullet Parent");
            _bulletList = new List<Transform>();
            StartCoroutine(findSplineCo());
        }

        private void Update()
        {
            if (canMove)
            {
                movement();
                shootControl();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "FinishLine":
                    GameManager.Instance.LevelComplete();
                    break;

                case "GoodCollectable":
                    var data = DataController.Instance.collectable.CoinValue;
                    UiController.Instance.AddCoin(data);
                    Destroy(other.gameObject);
                    break;

                case "Ammu":
                    UiController.Instance.AddHealth();
                    Destroy(other.gameObject);
                    break;
            }

            if (other.GetComponent<NPCController>() && !other.GetComponent<NPCController>().virus)
            {
                StartCoroutine(downgradeSpeed());
            }
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, shoorDistance);
        }

        #endregion

        #region Custom Methodes

        private void movement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mouseXStartPos = Input.mousePosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                _swipDelta = Input.mousePosition.x - _mouseXStartPos;
                _mouseXStartPos = Input.mousePosition.x;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _swipDelta = 0;
            }

            xMove += _swipDelta * horizontalSpeed * Time.deltaTime;
            xMove = Mathf.Clamp(xMove, -maxHorizontal, maxHorizontal);
            spline.motion.offset = new Vector2(xMove, spline.motion.offset.y);

        }

        private void shootControl()
        {
//            RaycastHit hit;
            Collider[] targets = Physics.OverlapSphere(transform.position, shoorDistance);
            if (targets.Length <= 0) return;

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].GetComponent<NPCController>() && targets[i].tag == "Enemy")
                {
                    _currentShootTime -= Time.deltaTime;
                    if (_currentShootTime <= 0)
                    {
                        _currentShootTime = shootTime;
                        Transform _targetPoint = targets[i].transform;
                        shootPoint.LookAt(_targetPoint.position);
                        shoot();
                    }
                }
            }
        }

        private void shoot()
        {
            for (int i = 0; i < _bulletList.Count; i++)
            {
                if (!_bulletList[i].gameObject.activeInHierarchy)
                {
                    _bulletList[i].transform.position = shootPoint.position;
                    _bulletList[i].transform.rotation = shootPoint.rotation;
                    _bulletList[i].gameObject.SetActive(true);
                    return;
                }
            }
            var _bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation, _bulletParent.transform);
            _bulletList.Add(_bullet);

        }

        public void TakeDamage(int value)
        {
            var data = DataController.Instance.collectable.PlayerCurrentHealth;
            data -= value;
            DataController.Instance.collectable.PlayerCurrentHealth = data;
            UiController.Instance.UpdateHealth(data);
            print(data);
            if (data <= 0)
            {
                dead();
            }
        }

        private void dead()
        {
            if (_death) return;
            GameManager.Instance.LevelFail();
            _death = true;
        }


        IEnumerator findSplineCo()
        {
            while (spline == null)
            {
                yield return new WaitForEndOfFrame();
                splineComputer = FindObjectOfType<SplineComputer>();
                spline.spline = splineComputer;
            }
        }

        private IEnumerator downgradeSpeed()
        {
            currentSpeed /= 2;
            spline.followSpeed = currentSpeed;
            yield return new WaitForSeconds(0.5f);
            while (currentSpeed != maxSpeed)
            {
                yield return new WaitForEndOfFrame();
                currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, 10 * Time.deltaTime);
                spline.followSpeed = currentSpeed;
            }
        }

        #endregion

        #region Delegate Methodes

        private void OnLevelComplete()
        {
            spline.follow = false;
            _currentShootTime = shootTime;
        }

        private void OnLevelFail()
        {
            canMove = false;
            spline.followSpeed = 0;


        }
        private void OnLevelStart()
        {
            canMove = true;
            spline.followSpeed = currentSpeed;

        }

        #endregion


    }
}
