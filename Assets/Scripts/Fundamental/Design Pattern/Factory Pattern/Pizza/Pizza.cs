using System.Collections.Generic;
using UnityEngine;

namespace FactoryPattern
{
    public abstract class Pizza
    {
        public string Name;
        public string Dough;
        public string Sauce;
        private List<string> Toppings = new List<string>();

        public void Prepare()
        {
            Debug.Log("Prepare " + Name);
            Debug.Log("Tossing dough...");
            Debug.Log("Adding sauce...");
            Debug.Log("Adding toppings: ");

            foreach (string item in Toppings)
            {
                Debug.Log("   " + item);

            }
        }

        public void Bake()
        {
            Debug.Log("Bake for 25 minutes at 350");
        }

        public void Cut()
        {
            Debug.Log("Cut the pizza into diagonal slices");
        }

        public void Box()
        {
            Debug.Log("Place pizza in official PizzaStore box");
        }

        public string getName()
        {
            return Name;
        }

        public override string ToString()
        {
            string display = "---- " + Name + " ----\n" +
                            Dough + "\n" +
                            Sauce + "\n";
            foreach (string topping in Toppings)
            {
                display += topping + "\n";
            }
            return display;
        }
    }




}


