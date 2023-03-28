using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HottieLife
{
    public enum ProgressStatus { success, fallback }

    public class PlayerManager : MonoBehaviour
    {
        public ProgressStatus progressStatus = ProgressStatus.success;

        public static PlayerManager Instance;

        [SerializeField] private ClothState currentCloth = ClothState.Natural;
        [SerializeField] private GameObject[] ClothObjects;
        [SerializeField] private Text playerStatus;

        private float currentClothState;
//        private float maxSexiness = 1;
        [SerializeField] private float CollectableRatio = 0.25f;
        private int clothStateNum = (int)(ClothState.Natural);
        private float firstPos;
        private void Awake()
        {
            Instance = this;
            ClothObjects[clothStateNum].gameObject.SetActive(true);
            playerStatus.text = currentCloth.ToString();
            firstPos = transform.position.x;

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("GoodCollectable"))
            {
                CalculateClothStateBar(CollectableRatio);
                Destroy(other.gameObject);

            }
            else if (other.CompareTag("BadCollectable"))
            {
                CalculateClothStateBar(-CollectableRatio);
                Destroy(other.gameObject);

            }
            else if (other.CompareTag("FinishLine"))
            {
                StartCoroutine(GoToCenter());
                print("finish");

            }
        }

        public void CalculateClothStateBar(float value)
        {
            currentClothState += value;

            if (currentClothState < 0)
            {
                ChangeCloth(-1);
                currentClothState = 1;
                progressStatus = ProgressStatus.fallback;

            }
            else if (currentClothState >= 1)
            {
                ChangeCloth(1);
                currentClothState = 0;
                progressStatus = ProgressStatus.success;

            }
            currentCloth = (ClothState)clothStateNum;
            playerStatus.text = currentCloth.ToString();
            HUiManager.Instance.ClothStateBar.fillAmount = currentClothState;

        }


        private void ChangeCloth(int value)
        {
            clothStateNum += value;

            for (int i = 0; i < ClothObjects.Length; i++)
            {
                ClothObjects[i].gameObject.SetActive(false);
            }
            clothStateNum = Mathf.Clamp(clothStateNum, 0, ClothObjects.Length - 1);

            ClothObjects[clothStateNum].gameObject.SetActive(true);
        }

        IEnumerator GoToCenter()
        {
            var playerMovement = GetComponent<PlayerMovement>();
            playerMovement.playerSpeed *= 2;
            playerMovement.canControl = false;

            while (true)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(firstPos, transform.position.y, transform.position.z), 4 * Time.deltaTime);
            }

        }
    }
}
