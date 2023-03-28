using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fundamental
{
    public class LinkListDotNet : MonoBehaviour
    {
        LinkedList<int> _linkList = new LinkedList<int>();

        private void Start()
        {
            _linkList.AddFirst(3);
            _linkList.AddFirst(4);
            _linkList.AddFirst(5);
            _linkList.AddFirst(7);
            _linkList.AddFirst(5);
            foreach (var item in _linkList)
            {
                Debug.Log(item);    
            }

        }
    }

}
