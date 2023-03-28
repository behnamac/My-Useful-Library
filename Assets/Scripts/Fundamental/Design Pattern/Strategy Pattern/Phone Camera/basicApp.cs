using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class basicApp : camera
    {

        public basicApp()
        {
            ishareBahavior = new text();
            ishareBahavior.share();
        }


        public override void Edit()
        {
            Debug.Log("I have basic tools for app");
        }

    }
}
