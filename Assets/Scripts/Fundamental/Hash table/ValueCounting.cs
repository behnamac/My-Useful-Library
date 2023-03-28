using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueCounting : MonoBehaviour
{
    [SerializeField] private List<string> items = new List<string>() { "apple", "pear", "orange", "banana", "apple",
                                           "orange", "apple", "pear", "banana", "orange",
                                           "apple", "kiwi", "pear", "apple", "orange" };

    Dictionary<string, int> counter = new Dictionary<string, int>();
    [SerializeField] private bool active;

    private void Start()
    {
        if (!active) return;

        foreach (string item in items)
        {
            if (counter.ContainsKey(item))
            {
                counter[item]++;
            }
            else
            {
                counter[item] = 1;
            }
        }

        foreach (KeyValuePair<string, int> entry in counter)
        {
            Debug.Log(entry.Key + ": " + entry.Value);
        }

    }

}



