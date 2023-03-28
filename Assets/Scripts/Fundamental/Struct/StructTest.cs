using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructTest : MonoBehaviour
{
    public Cloth[] ClothList;

    private void Start()
    {
        for (int i = 0; i < ClothList.Length; i++)
        {
            ClothList[i].PrintCloth();
        }
    }

}

[System.Serializable]
public struct Cloth
{
    public string Brand;
    public int Price;
    public int Model;
    public string[] type;

    

    public void PrintCloth()
    {
        Debug.Log("Brand: " + Brand + " Price: " + "Model: " + Model);
    }
}
