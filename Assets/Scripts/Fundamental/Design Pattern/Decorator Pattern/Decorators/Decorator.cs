using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorPattern
{
    public abstract class Decorator : Beverage
    {
        public abstract override string Description();
           
        
    }
}
