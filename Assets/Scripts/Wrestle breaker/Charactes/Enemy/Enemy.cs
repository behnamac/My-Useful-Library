using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    public class Enemy : Wreslers
    {
        public Transform Point;
        [SerializeField] private Transform TargetHand;

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
            TargetHand = GameObject.FindGameObjectWithTag("X").transform;
        }

        public override void Death()
        {
            base.Death();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            Anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            Anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            if (TargetHand)
            {
                Anim.SetIKPosition(AvatarIKGoal.RightHand, TargetHand.position);
                Anim.SetIKRotation(AvatarIKGoal.RightHand, TargetHand.rotation);
            }
        }

    }

}
