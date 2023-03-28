using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCSellController : MonoBehaviour
{
    public static FCSellController Instance;

    [SerializeField] bool setPrice;

    [HideInInspector] public float income;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        income = PlayerPrefs.GetFloat("IncomeUpgrade" + gameObject.name);
    }
    public void Upgrade(float value)
    {
        income += value;
        PlayerPrefs.SetFloat("IncomeUpgrade" + gameObject.name, income);
    }
}
