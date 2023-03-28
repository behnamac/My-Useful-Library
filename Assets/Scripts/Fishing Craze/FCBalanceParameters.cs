using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Fishing Craze/BalanceParameters")]

public class FCBalanceParameters : ScriptableObject
{
    [Header("Player First Speed")]

    public float PlayerSpeed = 5f;

    [Header("Fishes First Price")]

    public float fish1Price = 4f;
    public float fish2Price = 6f;
    public float fish3Price = 8f;



}
