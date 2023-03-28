using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class Stack : MonoBehaviour
    {
        private Stack<int> stack = new Stack<int>();
        Queue<int> queue = new Queue<int>();


        void Start()
        {
            // Adding items to the stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(6);
            stack.Push(7);

            print("stack count: " + stack.Count);
            // Removing items from the stack
            Debug.Log("stack: " + stack.Pop()); // Output: 3
            Debug.Log("stack: " + stack.Pop()); // Output: 2
            Debug.Log("stack: " + stack.Pop()); // Output: 1


            // Adding items to the queue
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(6);
            queue.Enqueue(7);


            // Removing items from the queue
            Debug.Log("queue: " + queue.Dequeue()); // Output: 1
            Debug.Log("queue: " + queue.Dequeue()); // Output: 2
            Debug.Log("queue: " + queue.Dequeue()); // Output: 3
        }

    }

}
