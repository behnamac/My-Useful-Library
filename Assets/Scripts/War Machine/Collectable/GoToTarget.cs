using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachine
{
    public class GoToTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _distance = 4f;
        [SerializeField]private float speed = 20f;
        private bool active;

        private void OnEnable()
        {
            _target = FindObjectOfType<PlayerMove>().transform;
        }
        

        private void Update()
        {
            if (Vector3.Distance(transform.position, _target.position) <= _distance||active)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
                active = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _distance);
        }

    }
}
