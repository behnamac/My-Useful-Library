using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

namespace CatchTheGiant
{
    public class CGUIManager : MonoBehaviour
    {
        public static CGUIManager Instance;
        public GameObject WinPanel;
        public GameObject losePanel;
        private Transform gamePlay;

        [HideInInspector] public int GiantScore;

        [SerializeField] CGEconomyManager economy;
        [SerializeField] private Text currencyTxt;
        [SerializeField] private Transform coinImg;

        [SerializeField] private Image coinSpawnImg;

        private float currency;


        private void OnEnable()
        {
            CGGameManager.LevelLose += death;
            CGGameManager.LevelWin += Win;
        }

        private void Awake()
        {
            Instance = this;
            GiantScore = economy.Giantscore;
            currency = PlayerPrefs.GetFloat("CGCurrency", economy.firstMoney);
            gamePlay = GameObject.FindGameObjectWithTag("Panel").transform;

        }

        private void death()
        {
            losePanel.gameObject.SetActive(true);
        }

        private void Win()
        {
            WinPanel.gameObject.SetActive(true);
        }

        public void SetCurrencyNumber(int score)
        {
            currency += score;
            PlayerPrefs.SetFloat("CGCurrency", currency);
            currencyTxt.text = currency.ToString();
            StartCoroutine(coinMovementAnimationCo(score));
        }

        IEnumerator coinMovementAnimationCo(int value)
        {
            yield return new WaitForEndOfFrame();

            var cointFirstPos = Camera.main.WorldToScreenPoint(CGPlayerList.Instance.transform.position * 2);
            for (int i = 0; i < value; i++)
            {
                var spawnImg = Instantiate(coinSpawnImg, cointFirstPos, Quaternion.identity, gamePlay);
                spawnImg.transform.localScale = Vector3.one;
                spawnImg.transform.DOMove(coinImg.transform.position, 0.2f + i / 10f).SetDelay(0.5f).OnComplete(() =>
                Destroy(spawnImg)
                );
            }
        }


    }
}


