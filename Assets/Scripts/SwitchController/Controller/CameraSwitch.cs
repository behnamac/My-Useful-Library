using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace switchCotroller
{
    public class CameraSwitch : MonoBehaviour
    {
        public static CameraSwitch Instance;

        [SerializeField] private CameraMode[] cameraSet;
        [SerializeField] private float followSpeed = 2;
        private Dictionary<string, CameraMode> cameraDic;

        private Camera _cam;
        private bool _canFollow;
        private Transform _traget;
        private string cameraType;

        #region Unity Methods

        private void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
            GameManager.OnLevelFailed += OnLevelFailed;
            GameManager.OnLevelComplete += OnLevelComplete;
        }
        private void OnDisable()
        {
            GameManager.OnLevelStart -= OnLevelStart;
            GameManager.OnLevelFailed -= OnLevelFailed;
            GameManager.OnLevelComplete -= OnLevelComplete;
        }

        private void Awake()
        {
            if (!Instance) Instance = this;
            SetCamera();
            _traget = FindObjectOfType<Player>().transform;
        }

        private void Update()
        {
            if (!_canFollow) return;
            Following();
        }

        #endregion

        #region Custom Methodes

        private void SetCamera()
        {
            cameraDic = new Dictionary<string, CameraMode>();
            for (int i = 0; i < cameraSet.Length; i++)
            {
                cameraDic.Add(cameraSet[i].Name, cameraSet[i]);
            }
            _cam = Camera.main;
            ChangingCameraView(out cameraType);

        }       

        public void ChangingCameraView(out string value)
        {
            value = SetCamType();
            var pos = cameraDic[value].Pos;
            var Rot = cameraDic[value].Rot;
            _cam.transform.DOLocalMove(pos, 1);
            _cam.transform.DOLocalRotate(Rot, 1);
        }

        private string SetCamType()
        {
            switch (cameraType)
            {
                case "TopDown":
                    cameraType = "3rdPerson";
                    GameManager.Instance.GameState = State.ThirdPerson;
                    break;
                case "3rdPerson":
                case "Start":
                    cameraType = "TopDown";
                    GameManager.Instance.GameState = State.TopDown;
                    break;
                default:
                    cameraType = "Start";
                    break;
            }
            return cameraType;
        }

        private void Following()
        {
            transform.position = Vector3.MoveTowards(transform.position, _traget.position, followSpeed);
        }

        #endregion

        #region Delegate Methods

        private void OnLevelStart()
        {
            ChangingCameraView(out cameraType);
            _canFollow = true;

        }
        private void OnLevelFailed()
        {

        }

        private void OnLevelComplete()
        {

        }
        #endregion


        [System.Serializable]
        public class CameraMode
        {
            public string Name;
            public Vector3 Pos;
            public Vector3 Rot;
        }
    }

}
