using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrestleBreaker
{
    public class ActiveRagdoll : MonoBehaviour
    {
        private Wreslers wreslers;
        private  Collider[] allColliders;
        private  Rigidbody[] allRigidbody;
        private void Awake()
        {
            TryGetComponent(out wreslers);
            allColliders = GetComponentsInChildren<Collider>();
            allRigidbody = GetComponentsInChildren<Rigidbody>();

            foreach (var item in allRigidbody)
            {
                item.isKinematic = true;
            }
            foreach (var item in allColliders)
            {
                item.enabled = false;
            }
        }
        private void OnEnable()
        {
            wreslers.OnDead += Activate;
        }
        private void OnDisable()
        {
            wreslers.OnDead -= Activate;
        }



        public void Activate()
        {
            foreach (var item in allRigidbody)
            {
                item.isKinematic = false;
            }
            foreach (var item in allColliders)
            {
                item.enabled = true;
            }
            //print("activeRagdol");
        }

    }

}
