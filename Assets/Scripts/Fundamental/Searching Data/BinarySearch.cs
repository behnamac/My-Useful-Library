using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinarySearch : MonoBehaviour
{


    // binary search = Search algorithm that finds the position
    //				   of a target value within a sorted array.
    //				   Half of the array is eliminated during each "step"
    [SerializeField] private int[] array = new int[1000000];
    [SerializeField] private int target = 777777;
    [SerializeField] private bool active;

    private void Start()
    {
        if (!active) return;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

       // int index = array.binarySearch(array, target);
        int index = binarySearch(array, target);

        if (index == -1)
        {
            print(target + " not found");
        }
        else
        {
            print("Element found at: " + index);
        }

    }

    private static int binarySearch(int[] array, int target)
    {

        int low = 0;
        int high = array.Length - 1;

        while (low <= high)
        {

            int middle = low + (high - low) / 2;
            int value = array[middle];
            //print("middle: " + value);
            if (value < target) low = middle + 1;
            else if (value > target) high = middle - 1;
            else return middle; //target found
        }

        return -1;
    }

}
