using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;


namespace DestroyTheInfected
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private float normalSpeed;
        [SerializeField] private float virusSpeed;
        [SerializeField] private float horizontalSpped;

        private bool _canMove;
        private SplineFollower _spline;
        [SerializeField] private Transform _target;

        private Transform _finishLine;
        private float _maxFinishLineDistance = 40;

        public bool virus;
        [SerializeField] private Color virusColor;
        [SerializeField] private MeshRenderer[] NPCMesh;
        private float _virusLine;
        private bool canAttack;

        [SerializeField] private float rediusAttack;
        [SerializeField] private LayerMask layer;

        [SerializeField] private GameObject Capsul;



        #region Unity Methods

        private void OnEnable()
        {
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFail += OnLevelFail;
            GameManager.OnLevelStart += OnLevelStart;
        }
        private void OnDestroy()
        {
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFail -= OnLevelFail;
            GameManager.OnLevelStart -= OnLevelStart;
        }
        private void Awake()
        {
            _spline = GetComponent<SplineFollower>();
        }

        private void Start()
        {
            _finishLine = GameObject.FindGameObjectWithTag("FinishLine").transform;

        }

        private void Update()
        {
            if (_canMove && virus)
                virusMovement();
        }

        private void OnLevelComplete()
        {
            _spline.follow = false;
        }
        private void OnLevelFail()
        {
            _spline.follow = false;
        }
        private void OnLevelStart()
        {
            _canMove = true;
            Initialized();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<NPCController>() && !other.GetComponent<NPCController>().virus)
            {
                if (!virus || !canAttack) return;
                _target = null;
                other.GetComponent<NPCController>().ActiveVirus();
                canAttack = false;
                Invoke(nameof(activeAttack), 5);
             //   print("Collide");
            }
        }

        #endregion

        #region Custom Methods

        private void Initialized()
        {
            var data = DataController.Instance.collectable;
            data.EnemyCurrentHealth = data.EnemyMaxHealth;

            if (virus)
            {
                ActiveVirus();
                _spline.followSpeed = virusSpeed;
                _virusLine = Random.Range(-1, 1);
            }
            else
            {
                _spline.followSpeed = normalSpeed;
            }
        }

        //-------------------------- Active virus --------------------------

        private void ActiveVirus()
        {
            var distance = Vector3.Distance(transform.position, _finishLine.position);
            if (distance < _maxFinishLineDistance) return;

            virus = true;
            VirusList.Innstance.AddList(this);

            _spline.direction = Spline.Direction.Forward;

            for (int i = 0; i < NPCMesh.Length; i++)
            {
                for (int j = 0; j < NPCMesh[i].materials.Length; j++)
                {
                    NPCMesh[i].GetComponent<MeshRenderer>().materials[j].color = virusColor;
                }
            }
            gameObject.tag = "Enemy";

            float _attackTime = 5;
            Invoke(nameof(activeAttack), _attackTime);
            increaseSpeed(1f);
        }

        private void activeAttack()
        {
            canAttack = true;
        }

        private void increaseSpeed(float t)
        {
            _spline.followSpeed = virusSpeed * 2;
            Invoke(nameof(decreaseSpeed), t);
        }

        private void decreaseSpeed()
        {
            _spline.followSpeed = virusSpeed;
        }

        //---------------------------------------------------------------


        private void virusMovement()
        {
            if (_target != null && !_target.GetComponent<NPCController>().virus)
            {
                var _targetToMove = _target.GetComponent<SplineFollower>();
                var _speed = 10;
                _spline.motion.offset = Vector2.MoveTowards(_spline.motion.offset, _targetToMove.motion.offset, _speed * Time.deltaTime);
                return;
            }
            if (canAttack)
            {
                _target = findTarget();
            }

            if (_target == null)
            {
                _spline.motion.offset = Vector2.MoveTowards(_spline.motion.offset, new Vector2(_virusLine, _spline.motion.offset.y),
                    horizontalSpped * Time.deltaTime);
            }
        }

        private Transform findTarget()
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, rediusAttack, layer);

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].GetComponent<NPCController>() &&
                    !targets[i].GetComponent<NPCController>().virus &&
                    targets[i].transform.position.z > transform.position.z)
                {
                    return targets[i].transform;
                }
            }
            return null;
        }


        public void Damage(int value)
        {
            var _health = DataController.Instance.collectable.EnemyCurrentHealth;
            _health -= value;
           DataController.Instance.collectable.EnemyCurrentHealth=_health;

            if (_health <= 0 && virus)
                dead();
            
        }

        private void dead()
        {
            gameObject.tag =null;
            _spline.followSpeed = 0;
            virus = false;
            Capsul.gameObject.SetActive(true);
            UiController.Instance.AddCoin(5);
            var _killedEnemy = DataController.Instance.collectable.KilledEnemy++;
            UiController.Instance.UpdateVirusText(_killedEnemy);
            VirusList.Innstance.RemoveList(this);
            PlayerController.Instance.TakeDamage(10);
            Destroy(gameObject, 5f);

        }


        #endregion
    }
}
