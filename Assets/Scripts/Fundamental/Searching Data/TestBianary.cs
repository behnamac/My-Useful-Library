using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBianary : MonoBehaviour
{
    [SerializeField] private int bad=4;
    [SerializeField]int Input = 5;

        public int FirstBadVersion(int n) {
            int left = 1;
            int right = n;
    
            while (left < right) {
                // int mid = (right + left) / 2;
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid)) {
                    right = mid;
                } else {
                    left = mid + 1;
                }
            }
    
            return left;
        }

   

    private bool IsBadVersion(int version)
    {
        return version==bad;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        IsBadVersion(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
