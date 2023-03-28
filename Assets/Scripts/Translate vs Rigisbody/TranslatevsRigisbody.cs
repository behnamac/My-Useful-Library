using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public class TranslatevsRigisbody : MonoBehaviour
    {

        public enum MoveType { Translate, RigidbodyVelocity,RigidbodyAddForce,RigidbodyMovePosition };

        [SerializeField] private MoveType moveType;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float[] ratio=new float[3];

        private Rigidbody _mybody;

        private void Awake()
        {
            _mybody = GetComponent<Rigidbody>();
        }

      

        private void Update()
        {

            if (moveType == MoveType.Translate)
            {
                MoveWithTranslate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }

        private void FixedUpdate()
        {
            switch (moveType)
            {
                case MoveType.RigidbodyVelocity:
                    MoveWithVelocity(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    break;
                case MoveType.RigidbodyAddForce:
                    MoveWithAddForce(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    break;
                case MoveType.RigidbodyMovePosition:
                    MoveWithMovePosition(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    break;
            }            
            
        }

        private void MoveWithTranslate(float x, float y)
        {
            Vector3 _move = new Vector3(x, 0, y);
            transform.Translate(_move * speed * Time.deltaTime);
        }

        private void MoveWithVelocity(float x, float y)
        {
            Vector3 _move = new Vector3(x, 0, y);

            _mybody.velocity = _move * (speed * ratio[0]) * Time.deltaTime;
        }

        private void MoveWithAddForce(float x, float y)
        {
            Vector3 _move = new Vector3(x, 0, y);

            _mybody.AddForce(_move * (speed * ratio[1]) * Time.deltaTime);
        }

        private void MoveWithMovePosition(float x, float y)
        {
            Vector3 _move = new Vector3(x,0, y);

            _mybody.MovePosition(transform.position+(_move * (speed * ratio[2]) * Time.deltaTime));
        }

    }
}
