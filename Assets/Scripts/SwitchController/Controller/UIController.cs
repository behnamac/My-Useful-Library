using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace switchCotroller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button startBtn;
        [SerializeField] private Button switchBtn;
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject gamePlayPanel;

        private string cameraType;
        #region Unity Methods

        private void Awake()
        {
            startBtn.GetComponent<Button>().onClick.AddListener(LevelStart);
        }
        private void OnEnable()
        {
            GameManager.OnLevelStart += OnLevelStart;
        }

        #endregion

        #region Delegate Methods

        private void OnLevelStart()
        {
            startPanel.gameObject.SetActive(false);
            gamePlayPanel.gameObject.SetActive(true);
            switchBtn.GetComponent<Button>().onClick.AddListener(() => { CameraSwitch.Instance.ChangingCameraView(out cameraType); });
        }


        #endregion

        #region Custom Methods

        private void LevelStart()
        {
            GameManager.Instance.OnStart();
        }
        #endregion
    }
}
