using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listTest : MonoBehaviour
{
    public List<int> player=new List<int>();
    [SerializeField] private int count = 5;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var random = Random.Range(0, 100);
            player.Add(random);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (player.Count == 0) return;
            var random = Random.Range(0, player.Count);
            player.RemoveAt(random);
            print(random);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (player.Count == 0) return;
            var random = Random.Range(0, player.Count);
            var random2 = Random.Range(0, player.Count);

            player.RemoveRange(random, random2);
            print(random+"---"+random2);
        }
    }



}
