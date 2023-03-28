using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FCStorage;


public enum FishType { fish1, fish2, fish3 }
public class FCAutoCollectable : MonoBehaviour
{
    [SerializeField] private FishType fishType;
    [SerializeField] private float addCoin = 5f;
    [SerializeField] private float CollectTime = 2f;
    public Vector3 Rotation = new Vector3(0, -90, 90);

    private void Start()
    {
        // Initialized();

    }

    private void OnEnable()
    {
        Initialized();
    }

    private void Initialized()
    {
        var playerPrefsController = FCPlayerPrefsController.Instance;
        switch (fishType)
        {
            case FishType.fish1:

                addCoin = playerPrefsController.GetFish1Price();
                break;

            case FishType.fish2:

                addCoin = playerPrefsController.GetFish2Price();

                break;

            case FishType.fish3:

                addCoin = playerPrefsController.GetFish3Price();

                break;
        }
    }

    public void ActiceCollect()
    {
        Invoke(nameof(Collect), CollectTime);
    }

    private void Collect()
    {
        FCPlayerAssets.Instance.SetAsset("Coin", addCoin + FCSellController.Instance.income, transform.position);
        Destroy(gameObject);
    }
}
