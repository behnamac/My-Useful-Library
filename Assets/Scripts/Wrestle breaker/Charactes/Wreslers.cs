using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    [RequireComponent(typeof(Animator))]
    public abstract class Wreslers : MonoBehaviour
    {
        public Action OnDead;
        [HideInInspector] public Animator Anim;
        protected ActiveRagdoll playRagdoll;
        [SerializeField] protected float Power; // player's power should be more than enemy's power other he cant's wresle and play animation
        [HideInInspector] public bool CanWrestle;
        protected float WrestleAnimValue;

        protected static readonly int WrestleForce = Animator.StringToHash("WrestleForce");
        protected static readonly int Wrestle = Animator.StringToHash("Wrestle");
        protected static readonly int Move = Animator.StringToHash("Move");




        #region Unity Methodes

        protected virtual void OnEnable()
        {
            LevelManager.OnLoadLevel += OnLoadLevel;
            LevelManager.OnLevelStart += OnLevelStart;
            LevelManager.OnLevelFail += OnLevelFail;

        }
        protected virtual void OnDisable()
        {
            LevelManager.OnLoadLevel -= OnLoadLevel;
            LevelManager.OnLevelFail -= OnLevelFail;
            LevelManager.OnLevelStart -= OnLevelStart;
        }


        protected virtual void Awake()
        {
            TryGetComponent(out playRagdoll);
            TryGetComponent(out Anim);

        }



        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            if (CanWrestle)
                DoWrestel();

        }

        #endregion

        #region Action Methodes

        protected virtual void OnLoadLevel(Level level)
        {

        }

        protected virtual void OnLevelStart(Level level)
        {
            CanWrestle = true;
            SetState();
        }
        public virtual void Death()
        {
            CanWrestle = false;
            Anim.enabled = false;
            OnDead?.Invoke();
        }
        protected virtual void OnLevelFail(Level level)
        {
            CanWrestle = false;
            WaveHolder.Instance.SetWrestelMode(WrestelMode.dead);
            //print("on level fail");
        }




        #endregion


        #region Custom Methodes

        protected virtual void DoWrestel()
        {
            SetWrestelAnim();
        }

        private void SetWrestelAnim()
        {
            WrestleAnimValue = Mathf.Clamp(WrestleAnimValue, 0, 1);
            Anim.SetFloat(WrestleForce, WrestleAnimValue);
        }

        public virtual void SetState()
        {
            var gameMode = WaveHolder.Instance.GameMode;
            if (gameMode == WrestelMode.Wrestle)
            {
                Anim.SetBool(Wrestle, true);
                Anim.SetBool(Move, false);
            }
            else if (gameMode == WrestelMode.Idle)
            {
                Anim.SetBool(Wrestle, false);
                Anim.SetBool(Move, false);
            }
            else
            {
                Anim.SetBool(Move, true);
                Anim.SetBool(Wrestle, false);
            }
        }

        

        #endregion
    }
}
