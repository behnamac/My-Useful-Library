using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{

    public class QuickSort : MonoBehaviour
    {

        //quick sort = moves smaller elements to left of a pivot.
        //recursively divide array in 2 partitions

        //run-time complexity = Best case O(n log(n))
        //Average case O(n log(n))
        //Worst case O(n^2) if already sorted

        //space complexity= O(log(n)) due to recursion

        [SerializeField] private int[] array = { 8, 2, 5, 3, 9, 4, 7, 6, 1 };
        [SerializeField] private bool active;

        private void Start()
        {
            if (!active) return;
            quickSort(array, 0, array.Length - 1);

            for (int i = 0; i < array.Length; i++)
            {
                print(i + " ");
            }

        }

        private void quickSort(int[] array, int start, int end)
        {

            if (end <= start) return; //base case(it means, we can't devide our array any further

            int pivot = partition(array, start, end);  //create pivot 
            quickSort(array, start, pivot - 1);  //left partition form pivot position
            quickSort(array, pivot + 1, end);    //right partition form pivot position
        }
        private static int partition(int[] array, int start, int end)
        {

            int pivot = array[end]; //first time start from last index
            int i = start - 1;      // that because i is -1 for the first time

            for (int j = start; j <= end; j++)
            {
                if (array[j] < pivot)  //when j is less that the pivote and we have to  ++ the i and swap between i&j
                {
                    i++;
                    int temp2 = array[i];
                    array[i] = array[j];
                    array[j] = temp2;
                }
            }
            i++;   // this happen when all j compared to pivot and it reached to the pivot, so ve switch between i and end(pivot)
            int temp = array[i];
            array[i] = array[end];
            array[end] = temp;

            return i; //location of pivot

        }
    }
}

