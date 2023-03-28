using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdaptorPattern
{
    public class WildTurkey : ITurkey
    {
        public void fly()
        {
            Debug.Log("I can fly");
        }
        public void gobble()
        {
            Debug.Log("gobble!!!!!");
        }

      
    }

}
