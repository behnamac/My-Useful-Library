using UnityEngine;

namespace StrategyPattern
{
    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            Debug.Log("Squeak");
        }
    }
}
