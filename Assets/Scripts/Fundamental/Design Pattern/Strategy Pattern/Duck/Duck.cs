using UnityEngine;

namespace StrategyPattern
{
    public abstract class Duck
    {
        public FlyBehavior flyBehavior;
        public QuackBehavior quackBehavior;

        public Duck()
        {
        }

        protected void setFlyBehavior(FlyBehavior fb)
        {
            flyBehavior = fb;
        }

        protected void setQuackBehavior(QuackBehavior qb)
        {
            quackBehavior = qb;
        }

        public abstract void display();
        

        

        public virtual void performFly()
        {
            flyBehavior.fly();
        }

        public virtual void performQuack()
        {
            quackBehavior.quack();
        }

        protected void swim()
        {
            Debug.Log("All ducks float, even decoys!");
        }

    }

}
