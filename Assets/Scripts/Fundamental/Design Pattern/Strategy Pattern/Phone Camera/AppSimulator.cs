using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Challenge
{
    public class AppSimulator : MonoBehaviour
    {
        basicApp _basicApp=new basicApp();
        void Start()
        {
            _basicApp.Edit();
            _basicApp.Save();
            _basicApp.ImplementShareBehavior();
        }
    }
}
