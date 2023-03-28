using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UnlockSystem
{
    public class UnlockSystem : MonoBehaviour
    {
        [SerializeField] private Image fill;
        [SerializeField] private ModelSource[] _models;
        [SerializeField] private Transform spawnPoint;

        private float _currentAmount;
        private bool complete;
        private GameObject _currentModel;
        private int _model;

        private void Awake()
        {
            Initialized();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                SetUpgrade();
            }
        }

        private void SetUpgrade()
        {
            if (_model < _models.Length)
            {
                Getter();
                float oldFill = CalculateFill(_currentAmount, _models[_model].TotalScore);
                float newFill = CalculateFill(_models[_model].AddScore, _models[_model].TotalScore);
                StartCoroutine(Setbar(oldFill, newFill, _models[_model + 1].ModelSprite));
            }
            else
            {
                complete = true;
            }
        }


        private IEnumerator Setbar(float oldValue, float newValue, Color color)
        {
            fill.color = color;
            fill.fillAmount = oldValue;
            var currentValue = oldValue + newValue;
            currentValue = Mathf.Clamp(currentValue, 0, 1);

            #region C# Code
            while (fill.fillAmount != currentValue && !complete)
            {
                yield return new WaitForEndOfFrame();
                fill.fillAmount = Mathf.MoveTowards(fill.fillAmount, currentValue, 0.3f * Time.deltaTime);
            }
            OnNextLevel();
            #endregion

            #region DoTween
            //fill.DOFillAmount(currentValue, 2).OnComplete(OnNextLevel);
            //yield return null;
            #endregion
        }

        public void OnNextLevel()
        {
            if (_model < _models.Length && _currentAmount + _models[_model].AddScore >= _models[_model].TotalScore)
            {
                Destroy(_currentModel);
                Setter();
              _currentModel = Instantiate(_models[_model].Model, spawnPoint.position, spawnPoint.rotation);
             fill.fillAmount = _currentAmount;
            }
            else
            {
                if (_model < _models.Length)
                    PlayerPrefsController.SetModelFill(_currentAmount + _models[_model].AddScore);
            }

        }

        private void Initialized()
        {
            Getter();
            _currentModel = Instantiate(_models[_model].Model, spawnPoint.position, spawnPoint.rotation);


            float currentFill = CalculateFill(_currentAmount, _models[_model + 1].TotalScore);
            fill.fillAmount = currentFill;

            fill.color = _models[_model + 1].ModelSprite;
        }       

        private float CalculateFill(float value, float total)
        {
            var dividing = value / total;
            return dividing;
        }

        private void Getter()
        {
            _model = PlayerPrefsController.GetCurrentModel(0);
            _currentAmount = PlayerPrefsController.GetModelFill(0);

        }

        private void Setter()
        {
            _model++;
            _currentAmount = 0;
            PlayerPrefsController.SetCurrentModel(_model);
            PlayerPrefsController.SetModel(_models[_model].Name);
            PlayerPrefsController.SetModelFill(0);
        }
    }


    [System.Serializable]
    public class ModelSource
    {
        public string Name;
        public GameObject Model;
        public float TotalScore;
        public float AddScore;
        public Color ModelSprite;
    }
}
