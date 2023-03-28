using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace switchCotroller
{
public class Enemy : Car
{
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
        protected override void Awake()
        {
            base.Awake();
        }
        protected override void OnLevelStart()
        {
            base.OnLevelStart();

        }
        protected override void OnLevelFailed()
        {
            base.OnLevelFailed();
        }
        protected override void OnLevelComplete()
        {
            base.OnLevelComplete();
        }
    }

}
