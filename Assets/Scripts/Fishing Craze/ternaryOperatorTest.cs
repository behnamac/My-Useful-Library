using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ternaryOperatorTest : MonoBehaviour
{
    bool isEven;
    [SerializeField]float number=4;

    // Start is called before the first frame update
    void Start()
    {
        terneryTest();
        print(terneryTest2());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public static bool GetBuyObject(string name, bool defaultValue = false) =>
            true ? PlayerPrefs.GetInt(name + "BuyObject", defaultValue ? 1 : 0) == 1 : false;

    private void terneryTest()
    {
        
        //if (number % 2 == 0)
        //{
        //    isEven = true;
        //}
        //else
        //{
        //    isEven = false;
        //}
        //print(isEven);

        bool result = true ? number % 2 == 0 : false;
        print(result);

    }

    bool terneryTest2() => true ? number % 2 == 0 : false;

}
