using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorPattern
{
    public class Sugar : Decorator
    {
        Beverage beverage;
        public Sugar(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override float Cost()
        {
            return beverage.Cost() + 0.2f;
        }

        public override string Description()
        {
            return beverage.Description() + " +Sugar";
        }
    }

}
