using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FCFishingRodeController : MonoBehaviour
{
    [HideInInspector] public List<FCFishController> fishes;
    [SerializeField] private Image timerImage;
//    private bool canFishing;
    Collider col;
    int upgradeNumber;


    private void Awake()
    {
        Initialized();
    }
    // Start is called before the first frame update
    void Start()
    {
        upgradeNumber = PlayerPrefs.GetInt("UpgradeFishSize", 1);


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Initialized()
    {
        fishes = new List<FCFishController>();
//        canFishing = true;
        col = GetComponent<Collider>();
    }


    [System.Serializable]
    public class UpgradeHolder
    {
        public int Price;
        public int targetShipNum;
        public float timeFishing;
        public GameObject[] activeGameObjects;
        public GameObject[] diactiveGameObject;
        [SerializeField] FCFishController[] fishes;

        public FCFishController GetFish()
        {
            return fishes[Random.Range(0, fishes.Length)];
        }
    }
}
