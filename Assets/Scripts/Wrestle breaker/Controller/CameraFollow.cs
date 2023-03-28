using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    public class CameraFollow : MonoBehaviour
    {

        [SerializeField] private float followSpeed;

        private Transform _target;
        private Vector3 _offset;
        private bool _canFollow;

        #region Unity Methodes

        private void OnEnable()
        {
            LevelManager.OnLevelComplete += OnLevelComplete;
            LevelManager.OnLevelFail += OnLevelFail;
            LevelManager.OnLevelStart += OnLevelStart;
        }
        private void OnDisable()
        {
            LevelManager.OnLevelComplete -= OnLevelComplete;
            LevelManager.OnLevelFail -= OnLevelFail;
            LevelManager.OnLevelStart -= OnLevelStart;
        }
        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _offset = transform.position - _target.position;

        }

        private void LateUpdate()
        {
            if (!_canFollow) return;
            Follow();
        }

        #endregion

        #region Custom Methodes

        private void Follow()
        {
            var offset = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, offset, followSpeed);
        }

        #endregion





        #region Action Methodes

        private void OnLevelComplete(Level level)
        {
            _canFollow = false;
        }
        private void OnLevelFail(Level level)
        {
            _canFollow = false;

        }
        private void OnLevelStart(Level level)
        {
            _canFollow = true;
        }
        #endregion


    }

}
