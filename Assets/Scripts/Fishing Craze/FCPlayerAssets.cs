using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FCPlayerAssets : MonoBehaviour
{
    public static FCPlayerAssets Instance;

    [SerializeField] private Asset[] AssetsList;

    private Dictionary<string, Asset> assetDic;





    private void Awake()
    {
        Instance = this;
        Initialized();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Initialized()
    {
        assetDic = new Dictionary<string, Asset>();
        for (int i = 0; i < AssetsList.Length; i++)
        {
            assetDic.Add(AssetsList[i].Name, AssetsList[i]);
            AssetsList[i].Value = PlayerPrefs.GetFloat("Asset" + AssetsList[i].Name, AssetsList[i].FirstValue);
            UpdateAssetText(AssetsList[i].Name);

        }
    }

    private void UpdateAssetText(string assetName)
    {
        if (assetDic[assetName].AssetText != null)
        {
            assetDic[assetName].AssetText.text = assetDic[assetName].Value.ToString("F0");
        }
    }


    public void SetAsset(string assetName, float value)
    {
        assetDic[assetName].Value += value;
        assetDic[assetName].Value = Mathf.Clamp(assetDic[assetName].Value, 0, assetDic[assetName].Value);
        PlayerPrefs.SetFloat("Asset" + assetName, assetDic[assetName].Value);
        UpdateAssetText(assetName);

       

    }

    public void SetAsset(string assetName, float value, Vector3 spawnPos)
    {
        assetDic[assetName].Value += value;
        assetDic[assetName].Value = Mathf.Clamp(assetDic[assetName].Value, 0, assetDic[assetName].Value);
        PlayerPrefs.SetFloat("Asset" + assetName, assetDic[assetName].Value);
        UpdateAssetText(assetName);

        Vector3 pos = Camera.main.WorldToScreenPoint(spawnPos);
        var d = Instantiate(assetDic[assetName].ImageAssets, pos, Quaternion.identity);
        Transform parent = GameObject.FindGameObjectWithTag("AssetParent").transform;
        d.SetParent(parent);
        d.localScale = Vector3.one;
        d.DOMove(assetDic[assetName].TargetImageAsset.position, 0.5f).OnComplete(() =>
        {
            Destroy(d.gameObject);
        });
          

       
    }

    public float GetAsset(string assetName)
    {
        return assetDic[assetName].Value;
    }

}

[System.Serializable]

public class Asset
{
    public string Name;
    public int FirstValue;
    [Space(5)]
    //public GameObject assetCanvas;
    public Text AssetText;
    public Transform ImageAssets;
    public Transform TargetImageAsset;
    [HideInInspector] public float Value;
}
