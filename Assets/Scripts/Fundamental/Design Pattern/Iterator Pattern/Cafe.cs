using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IteratorPattern
{
    public class Cafe : MonoBehaviour
    {
        private Menu PancackeHouseMenu;
        private Menu dinnerMenu;

        public Cafe(Menu PancackeHouseMenu, Menu dinnerMenu)
        {
            this.PancackeHouseMenu = PancackeHouseMenu;
            this.dinnerMenu = dinnerMenu;
        }

        //public void PrintMenu(Iterator<MenuItem> iterator)
        //{

        //}
    }

}
