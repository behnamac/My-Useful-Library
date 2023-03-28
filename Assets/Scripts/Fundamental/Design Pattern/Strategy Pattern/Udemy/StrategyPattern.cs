using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public interface IAbility
    {
        void Use(GameObject currentGameObject);
    }
    public class StrategyPattern : MonoBehaviour
    {
        #region old method
        //enum Ability
        //{
        //    Fireball,
        //    Rage,
        //    Heal
        //}
        // [SerializeField] Ability currentAbility = Ability.Fireball;
        #endregion

         public IAbility currentAbility = new Fireball();

        public void UseAbility()
        {
            currentAbility.Use(gameObject);
            #region old method
            //    switch (currentAbility)
            //    {
            //        case Ability.Fireball:
            //            Debug.Log("Launch Fireball");
            //            break;
            //        case Ability.Rage:
            //            Debug.Log("I always angry!");
            //            break;
            //        case Ability.Heal:
            //            Debug.Log("Here eat this!");
            //            break;               
            //    }
            #endregion
        }

       
    }


    public class Fireball : IAbility
    {
        public void Use(GameObject currentGameObject)
        {
            Debug.Log("Launch Fireball");
        }
    }
    public class Rage :MonoBehaviour,IAbility
    {
        public void Use(GameObject currentGameObject)
        {
            Debug.Log("I always angry!");
        }
    }
    public class Heal :ScriptableObject,IAbility
    {
        public void Use(GameObject currentGameObject)
        {
            Debug.Log("Heal!");
        }
    }
}
