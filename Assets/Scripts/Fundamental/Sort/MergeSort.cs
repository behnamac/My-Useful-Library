using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    // merge sort = recursively divide array in 2, sort, re-combine
    // run-time complexity = O(n Log n)
    // space complexity    = O(n)
    [SerializeField] private int[] array = { 8, 2, 5, 3, 4, 7, 6, 1 };

    [SerializeField] private bool active;

    void Start()
    {
        if (!active) return;
        mergeSort(array);

        for (int i = 0; i < array.Length; i++)
        {
            print(array[i] + " ");
        }
    }

    private static void mergeSort(int[] array)
    {

        int length = array.Length;
        if (length <= 1) return; //base case

        int middle = length / 2;
        int[] leftArray = new int[middle];
        int[] rightArray = new int[length - middle];

        int i = 0; //left array
        int j = 0; //right array

        for (; i < length; i++)
        {
            if (i < middle)
            {
                leftArray[i] = array[i];
            }
            else
            {
                rightArray[j] = array[i];
                j++;
            }
        }
        mergeSort(leftArray);
        mergeSort(rightArray);
        merge(leftArray, rightArray, array);
    }

    private static void merge(int[] leftArray, int[] rightArray, int[] array)
    {

        int leftSize = array.Length / 2;
        int rightSize = array.Length - leftSize;
        int i = 0, l = 0, r = 0; //indices

        //check the conditions for merging
        while (l < leftSize && r < rightSize)
        {
            if (leftArray[l] < rightArray[r])
            {
                array[i] = leftArray[l];
                l++;
            }
            else
            {
                array[i] = rightArray[r];
                r++;
            }
            i++;
        }
        while (l < leftSize)
        {
            array[i] = leftArray[l];
            i++;
            l++;
        }
        while (r < rightSize)
        {
            array[i] = rightArray[r];
            i++;
            r++;
        }
    }
}

