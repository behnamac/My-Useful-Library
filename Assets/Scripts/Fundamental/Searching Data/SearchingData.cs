using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingData : MonoBehaviour
{

    // linear search = Iterate through a collection one element at a time

    [SerializeField] int[] array = { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
    [SerializeField] private int itemToSearch;
    [SerializeField] private bool active;


    private void Start()
    {
        if (!active) return;

        int index = linearSearch(array, itemToSearch);

        if (index != -1)
        {
            print("Element found at index: " + index);
        }
        else
        {
            print("Element not found");
        }

    }



    private static int linearSearch(int[] array, int value)
    {

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

}
