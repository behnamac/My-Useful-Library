using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StrategyPattern;

namespace AdaptorPattern
{
    public class TurkeyAdaptor : Duck
    {
        ITurkey turkey;

        public TurkeyAdaptor(ITurkey turkey)
        {
            this.turkey = turkey;
        }
        public override void performFly()
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.Log(i + " times");
                turkey.fly();
            }
        }
        public override void performQuack()
        {
            turkey.gobble();
        }

        public override void display()
        {
            Debug.Log("I am Turkey");
        }


    }
}
