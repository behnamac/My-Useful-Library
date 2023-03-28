using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class BubbleSort : MonoBehaviour
    {
        [SerializeField] private int[] arr = { 5, 1, 4, 2, 8 };
        [SerializeField] private bool active;
        int temp;

        private void Awake()
        {
            if (!active) return;
            sort();
            Print();
        }
        private void sort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    print("Sec For");
                }
                print("First for");
            }
        }

        private void Print()
        {
            foreach (int item in arr)
            {
                Debug.Log(item + "");
            }
        }
    }
}
