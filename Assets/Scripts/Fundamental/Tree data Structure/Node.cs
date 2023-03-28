using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    [HideInInspector] public int data;
    [HideInInspector] public Node left;
    [HideInInspector] public Node right;

    public Node(int data)
    {
        this.data = data;
    }
}
