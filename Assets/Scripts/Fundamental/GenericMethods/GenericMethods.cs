using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class GenericMethods : MonoBehaviour
    {
        private void Start()
        {
            int[] numbers = { 1, 5, 3, 9, 7 };
            int maxNumber = FindMax(numbers);
            Debug.Log($"The maximum number is {maxNumber}");

            string[] strings = { "apple", "banana", "cherry" };
            string maxString = FindMax(strings);
            Debug.Log($"The maximum string is {maxString}");

        }


        public T FindMax<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("The array cannot be null or empty.");
            }

            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

    }

}
