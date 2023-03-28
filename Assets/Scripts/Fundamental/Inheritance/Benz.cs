using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fundamental
{
    public class Benz : MonoBehaviour
    {
        baseClass car,car2;

        private void Start()
        {
            car = new baseClass("benz", "red", 2001, 5, false);
            car2= new baseClass("Shevorlet", "white", 1990, 8, false);
            print(car.Name + car.Color + car.Model);
        
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                print(car.Drive(2));
                print(car2.Drive(8));
            }
        }


    }
}
