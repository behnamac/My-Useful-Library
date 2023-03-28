using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DestroyTheInfected
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance { get; private set; }


        #region FIELDS

        [SerializeField] private Transform target;
        private Vector3 offset;
        [SerializeField] private float followSpeed = 0.1f;

        private bool canFollow;

        #endregion

        #region PRIVATE METHODS


        private void Initialize()
        {
            // SET DEFAULT OFFSET
            offset = transform.position - target.position;

        }

        private void SmoothFollow()
        {
            var targetPos = target.position + offset;

            transform.forward = Vector3.Lerp(transform.forward, target.forward, 0.1f);

            var smoothFollow = Vector3.Lerp(transform.position, targetPos, followSpeed);

            transform.position = smoothFollow;

        }

        #endregion

        #region UNITY EVENT METHODS

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        private void Start() => Initialize();

        private void LateUpdate()
        {
            if (!canFollow) return;
            SmoothFollow();
        }

        private void OnEnable()
        {
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelFail += OnLevelFail;
            GameManager.OnLevelStart += OnLevelStart;

        }

        private void OnLevelComplete()
        {
            canFollow = false;
        }
        private void OnLevelFail()
        {
            canFollow = false;
        }
        private void OnLevelStart()
        {
            canFollow = true;
        }

        #endregion




    }
}
