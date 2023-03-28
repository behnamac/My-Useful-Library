using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class StrategyController : MonoBehaviour
    {
        [SerializeField] private StrategyPattern strategy;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                strategy.currentAbility = new Fireball();
                strategy.UseAbility();
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                strategy.currentAbility = new Rage();
                strategy.UseAbility();
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                strategy.currentAbility = new Heal();
                strategy.UseAbility();
            }

        }


    }
}