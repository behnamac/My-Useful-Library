using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private StatePattern state;
        private Animator anim;
        private string key;

        private void Awake()
        {
            TryGetComponent(out anim);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state.DoJump(out key);
                PlayAnimation();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                state.DoCrouch(out key);
                PlayAnimation();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                state.DoLand(out key);
                PlayAnimation();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                state.DoFall(out key);
                PlayAnimation();
            }
        }

        private void PlayAnimation()
        {
            anim.SetTrigger(key);
            print(key);
        }
    }
}
