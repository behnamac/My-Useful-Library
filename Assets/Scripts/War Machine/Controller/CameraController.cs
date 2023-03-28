using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace WarMachine
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance;

        [SerializeField] private Transform cameraPoint;

        [Header("Camera State")]
        [Space(5)]
        [SerializeField] private CameraSetting[] cameraList;
        private Dictionary<string, CameraSetting> cameraDic;

        [SerializeField] private Transform target;

        [SerializeField] private float cameraFollowSpeed = 5;
        [SerializeField] private float cameraRotateSpeed = 5;

        private Vector3 _pos;
        private Vector3 _rot;
        private bool _horizontalMove;
        private bool _canFollow;
        private bool _postLevel;

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            cameraDic = new Dictionary<string, CameraSetting>();

            for (int i = 0; i < cameraList.Length; i++)
            {
                cameraDic.Add(cameraList[i].Name, cameraList[i]);
            }

        }

        private void Start()
        {

            ChangeCameraPos("Upgrade");
        }

        private void LateUpdate()
        {
            if (_canFollow)
            {
                cameraFollow();
            }
            
            
        }


        private void OnEnable()
        {
            GameManager.OnLevelComplete += OnLevelComplete;
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelFaild += OnLevelFaild;
        }

        private void OnDisable()
        {
            GameManager.OnLevelComplete -= OnLevelComplete;
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelFaild -= OnLevelFaild;
        }

        #endregion

        #region CustomMethodes

        private void ChangeCameraPos(string name)
        {
            _pos = cameraDic[name].Pos;
            _rot = cameraDic[name].Rot;
            cameraPoint.DOLocalMove(_pos, 2);
            Quaternion rotate = Quaternion.Euler(_rot.x, _rot.y, _rot.z);
            cameraPoint.DOLocalRotateQuaternion(rotate, 2);
        }

        private void cameraFollow()
        {
            transform.position =Vector3.Slerp(transform.position,target.position,cameraFollowSpeed*Time.deltaTime);

            if (_postLevel)
            {
             transform.LookAt(target);
            }
            else
            {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, cameraRotateSpeed * Time.deltaTime);
            }
           // transform.forward = Vector3.Lerp(transform.forward, target.forward, 0.1f);

        }



        #endregion


        #region Delegate Methodes

        private void OnLevelComplete()
        {
            _postLevel = true;
           // _canFollow = false;

        }

        private void OnLevelStart()
        {
            _canFollow = true;
            ChangeCameraPos("InGame");
        }

        private void OnLevelFaild()
        {
            _canFollow = false;
        }
        #endregion
    }

    [System.Serializable]
    public class CameraSetting
    {
        public string Name;
        public Vector3 Pos;
        public Vector3 Rot;

    }
}
