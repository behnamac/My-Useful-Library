using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindMax : MonoBehaviour
{
   [SerializeField] private List<int> items = new List<int> { 6, 20, 8, 19, 56, 23, 87, 41, 49, 53 };

    [SerializeField] private bool active;

    private void Start()
    {
        if (!active) return;
        Debug.Log(find_max(items));

    }


    int find_max(List<int> items)
    {
        if (items.Count == 1)
        {
            return items[0];
        }

        int op1 = items[0];
       // Debug.Log(op1);
        int op2 = find_max(items.Skip(1).ToList());
        //Debug.Log(op1 + " " + op2);

        if (op1 > op2)
        {
            return op1;
        }
        else
        {
            return op2;
        }
    }


}
