using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class TargetChecker : MonoBehaviour
    {
        [SerializeField] private string[] targetTags;
        public  CarShoot carShoot { get; set; }

        private void OnTriggerStay(Collider other)
        {
            if (!carShoot) return;
            if (carShoot.target) return;
            CancelInvoke(nameof(NullTarget));
            if (other.gameObject.GetComponent<HealthControl>())
            {
                bool _find = false;
                for (int i = 0; i < targetTags.Length; i++)
                {
                    if(other.gameObject.CompareTag(targetTags[i]))
                    _find = true;
                }
                if (!_find) return;
                var _target = other.gameObject.GetComponent<HealthControl>();
                carShoot.target = _target;

            }           

            
        }


        private void OnTriggerExit(Collider other)
        {
            Invoke(nameof(NullTarget), 10);
        }

        private void NullTarget()
        {
            carShoot.target = null;

        }
    }
}
