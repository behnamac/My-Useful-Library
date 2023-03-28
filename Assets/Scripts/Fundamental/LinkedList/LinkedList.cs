using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class LinkedList : MonoBehaviour
    {
        Node head;
        int count;

        public LinkedList()
        {
            head = null;
            count = 0;

        }

        private void AddToFront(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            count++;
            print(data);
        }


        private void Start()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToFront(5);
            linkedList.AddToFront(2);
            linkedList.AddToFront(6);
            linkedList.AddToFront(1);
            linkedList.AddToFront(7);
            linkedList.AddToFront(3);
            
        }

        private void Update()
        {

        }

        private void Print()
        {
            Node node =head;
            while (node!=null)
            {
                Debug.Log(node.data);
                node = node.Next;
            }

        }
    }

    class Node
    {
        //own data
        public int data;
        //next box
        public Node Next;

        public Node(int data)
        {
            this.data = data;
            this.Next = null;
        }
    }
}
