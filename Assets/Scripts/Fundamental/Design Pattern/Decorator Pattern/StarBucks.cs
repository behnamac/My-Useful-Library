using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorPattern
{
    public class StarBucks : MonoBehaviour
    {
        Beverage beverage = new Sperso();
        Beverage beverage2 = new AppleJuice();

        void Start()
        {
            beverage = new Milk(beverage);
            beverage = new Milk(beverage);
            beverage = new Sugar(beverage);
            beverage2 = new Sugar(beverage2);
            print(beverage.Description()+" = "+beverage.Cost()+"₺");
            print(beverage2.Description() + " = " + beverage2.Cost() + "₺");

        }


    }

}
