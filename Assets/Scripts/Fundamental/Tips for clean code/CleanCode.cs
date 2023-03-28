using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCode
{
    public class CleanCode : MonoBehaviour
    {
        #region Expression
        // The Expression is the value
        private bool CanRegister(int age)
        {
            if (age > 18)
            {
                return true;
            }
            return false;

        }

        private bool _CanRegister(int age) => age > 18;

        #endregion

        

        #region Test Area

        private void Start()
        {
            print(_CanRegister(11));
        }

        #endregion
    }

}
