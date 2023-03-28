using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public ItemPropertise[] item;
    public ConstuctorExample[] playerProperties;
    // Start is called before the first frame update
    void Start()
    {
       // item = new ItemPropertise[3];
        playerProperties = new ConstuctorExample[3];
        playerProperties[0] = new ConstuctorExample("ali", "male");
        playerProperties[1] = new ConstuctorExample("ahmad", "male", 20, 183);
        playerProperties[2] = new ConstuctorExample("hamid");

        item[0].ItemIndex = 1;
        item[0].ItemName = "sward";
        item[0].Itemvalue = 200;
        item[1].ItemIndex = 2;
        item[1].ItemName = "blade";
        item[1].Itemvalue = 100;
        item[2].ItemIndex = 3;
        item[2].ItemName = "axe";
        item[2].Itemvalue = 250;
    }

    
}
