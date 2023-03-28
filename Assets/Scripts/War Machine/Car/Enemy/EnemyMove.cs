using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace WarMachine
{
    public class EnemyMove : MonoBehaviour
    {
        public bool CanChangeLine;
        public float DistanceToPlayer;
        public float FollowSpeed;
        public SplineFollower Spline;
        [HideInInspector] public Vector2 TargetLine;
        [HideInInspector] public Vector2 FirstLine;

        private Animator _anim;
        public float SpeedHorizontal;
        public float delayHorizontalMove=1f;
        private HealthControl _healthControl;
        private CarShoot _carShoot;
        private bool _canMove;

        #region Unity Methodes

        private void Awake()
        {
            Spline = GetComponent<SplineFollower>();
            TryGetComponent(out _healthControl);
            _healthControl.OnDead += Dead;
        }

        private void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFaild += OnLevelFaild;
            _anim = GetComponent<Animator>();
            _carShoot = GetComponent<CarShoot>();
            MoveToPlayer();
        }     

        private void Start()
        {

            if (CanChangeLine)
                Invoke(nameof(horizontalMovement), 0.1f);

        }

        private void OnDestroy()
        {
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelFaild -= OnLevelFaild;
            _healthControl.OnDead -= Dead;
        }

        #endregion


        private void MoveToPlayer()
        {
            if (!_canMove) return;
            Spline.followSpeed = FollowSpeed;
        }

        private void horizontalMovement()
        {
            StartCoroutine(horizontalMovementCo(TargetLine));

        }

        IEnumerator horizontalMovementCo(Vector2 target)
        {
            yield return new WaitForSeconds(delayHorizontalMove);
            if (target.x > Spline.motion.offset.x)
            {
                _anim.SetBool("Right", true);
            }
            else if (target.x < Spline.motion.offset.x)
            {
                _anim.SetBool("Left", true);
            }

            while (target.x != Spline.motion.offset.x)
            {
                yield return new WaitForEndOfFrame();
                Spline.motion.offset = Vector2.MoveTowards(Spline.motion.offset, target,
                    SpeedHorizontal * Time.deltaTime);
                if (target.x == Spline.motion.offset.x)
                {
                    _anim.SetBool("Right", false);
                    _anim.SetBool("Left", false);
                    if (target.x == FirstLine.x)
                    {
                        StartCoroutine(horizontalMovementCo(TargetLine));
                        break;
                    }
                    else if (target.x== TargetLine.x)
                    {
                        StartCoroutine(horizontalMovementCo(FirstLine));
                        break;
                    }
                }
            }

        }

        private void Dead()
        {
            Spline.enabled = false;
            int money = 10;
            UIManager.Instance.AddCoin(money);
            EnemySpawner.Instance.RemoveEnemy(this);
            _carShoot.CanShoot = false;

        }


        #region Delegate Methodes

        private void OnLevelStart()
        {
            _canMove = true;

        }

        private void OnLevelComplete()
        {

        }
        private void OnLevelFaild()
        {
            _canMove = false;

        }

        #endregion


    }
}
