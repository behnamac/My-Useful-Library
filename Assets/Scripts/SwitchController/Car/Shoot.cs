using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace switchCotroller
{
    public class Shoot : MonoBehaviour
    {
        private void Update()
        {
            if (GameManager.Instance.GameState != State.ThirdPerson)
                return;
            Shooting();            
        }

        private void Shooting()
        {

        }
    }
}
