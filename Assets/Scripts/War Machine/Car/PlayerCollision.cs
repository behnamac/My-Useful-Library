using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;


namespace WarMachine
{
    public class PlayerCollision : MonoBehaviour
    {
        private HealthControl _health;
        private PlayerUpgrade _playerUpgrade;
        [SerializeField]private CarScoreTextUI _carScoreTextUI;

        private float _healthValue=10f;
        private float _damageValue = -5f;

        private void Awake()
        {
            _health = GetComponent<HealthControl>();
            _playerUpgrade = GetComponent<PlayerUpgrade>();
        }


        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "Health":
                    _health.SetHealth(_healthValue);
                    other.gameObject.SetActive(false);
                    break;
                case "damageUp":
                   //unknown
                    break;
                case "explosion":
                case "Bullet":
                    _health.SetHealth(_damageValue);
                    other.gameObject.SetActive(false);
                    break;
                case "Armor":
                    _health.ActiveShield();
                    other.gameObject.SetActive(false);
                    break;
                case "FinishLine":
                    GameManager.Instance.LevelComplete();
                    break;
                case "Money":
                    UIManager.Instance.AddCoin(5);
                    _playerUpgrade.MoneyForUpgrade(5);
                    _carScoreTextUI.ActiveScoreText(5, _carScoreTextUI.spawnScoreTextPoint);
                    other.gameObject.SetActive(false);
                    break;              
               
              
            }
        }

        [System.Serializable]
        public class CarScoreTextUI
        {
             public Transform scoreText;
             public Transform spawnScoreTextPoint;

            public void ActiveScoreText(int value, Transform spawnPoint)
            {
                var _scoreParticle = Instantiate(scoreText, spawnPoint.position, spawnPoint.rotation,spawnPoint.transform);
                var _score = _scoreParticle.GetComponentInChildren<TextMeshProUGUI>();
                if (value >= 0)
                {
                    _score.text = "+ " + value;
                    _score.color = Color.green;
                }
                else
                {
                    _score.text = "- " + value;
                    _score.color = Color.red;
                }

                var scorePosition = _scoreParticle.position;
                _scoreParticle.DOLocalMoveY(scorePosition.y + 2, 1);
                _score.DOFade(0, 1);
                Destroy(_scoreParticle.gameObject, 1);
            }
        }
    }
}
