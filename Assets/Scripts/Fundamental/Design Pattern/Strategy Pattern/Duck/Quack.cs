using UnityEngine;

namespace StrategyPattern
{
    public class Quack : QuackBehavior
    {
        public void quack()
        {
            Debug.Log("Quack");
        }
    }
}

