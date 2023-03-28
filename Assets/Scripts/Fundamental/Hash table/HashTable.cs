using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashTable : MonoBehaviour
{
    [SerializeField]
    private string[] items = { "apple", "pear", "orange", "banana", "apple",
                           "orange", "apple", "pear", "banana", "orange",
                           "apple", "kiwi", "pear", "apple", "orange" };

    Dictionary<string, int> filter = new Dictionary<string, int>();

    [SerializeField] private bool active;

    void Start()
    {
        if (!active) return;

        foreach (string item in items)
        {
            filter[item] = 0;
        }
        HashSet<string> result = new HashSet<string>(filter.Keys);
        Debug.Log(string.Join(", ", result));

    }

}
