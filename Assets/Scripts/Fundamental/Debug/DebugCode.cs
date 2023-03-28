using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCode : MonoBehaviour
{
    int counter = 8;
    int Firstvalue=2;
    int ss;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < counter; i++)
        {
            Firstvalue++;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var value = calculate(Firstvalue);
            devide(5);
            Debug.Log("value: " + value);
        }

    }

    private float calculate(int value)
    {
         ss += value * 2;
        return ss;
    }
    private float devide(int value)
    {
        float div = value / 2;
        div--;
        return div;
    }
}
