using UnityEngine;

namespace StrategyPattern
{
    public class RedHeadDuck : Duck
    {
        public override void display()
        {
            Debug.Log("I am RedHead");
        }

        public RedHeadDuck()
        {
             quackBehavior= new Quack();
            flyBehavior = new FlyWithWings();
        }

        


    }

}
