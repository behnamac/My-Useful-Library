using UnityEngine;
using DG.Tweening;

namespace Fundamental
{
    public class LookRotation : MonoBehaviour
    {
        public enum LookRotateMode { Slerp, DoTween,LookAt }
        [SerializeField] private LookRotateMode RotateMode=LookRotateMode.Slerp;
        private Transform _target;
        [SerializeField] private float speed = 5f;


        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (RotateMode==LookRotateMode.Slerp)
            {
            Vector3 _delta = _target.position - transform.position;
            _delta.y = 0;
            Quaternion _rot = transform.rotation;
            transform.rotation = Quaternion.Slerp(_rot, Quaternion.LookRotation(_delta), speed * Time.deltaTime);
            }
            else if(RotateMode == LookRotateMode.DoTween)
            {
                var target = new Vector3(_target.position.x, 0, _target.position.z);
                transform.DOLookAt(target, speed);
            }
            else
            {
                var target = new Vector3(_target.position.x, 0, _target.position.z);
                transform.LookAt(target);
            }
            
        }
    }
}
