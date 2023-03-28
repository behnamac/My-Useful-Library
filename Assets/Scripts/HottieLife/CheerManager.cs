using UnityEngine;

namespace HottieLife
{
    public class HCheerManager : MonoBehaviour
    {
        [SerializeField] private People[] peopleList;
        float timer = 1;

        void Awake()
        {
            peopleList = FindObjectsOfType<People>();
        }

        // Update is called once per frame
        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1;
                checkProgressStatus();
            }

        }
        void checkProgressStatus()
        {
            if (PlayerManager.Instance.progressStatus == ProgressStatus.success)
            {
                foreach (var item in peopleList)
                {
                    item.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
            else
            {
                foreach (var item in peopleList)
                {
                    item.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }

}
