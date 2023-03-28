using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace switchCotroller
{
    public class Player : Car
    {
        [SerializeField] private float controlSpeed = 0.7f;
        [SerializeField] private float maxHorizontal = 4;
        private Vector3 _firstPos;
        private bool canControl;
        private float _delta;


        #region  Unity Methodes

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

        protected override void Update()
        {
            base.Update();

            if (!canControl)
                return;
            Controling();
        }

        #endregion

        #region Delegate Methods

        protected override void OnLevelStart()
        {
            base.OnLevelStart();
            CanMove = true;
            canControl = true;
        }
        protected override void OnLevelFailed()
        {
            base.OnLevelFailed();
        }
        protected override void OnLevelComplete()
        {
            base.OnLevelComplete();
        }
        #endregion

        #region Custom Methods

        private void Controling()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _firstPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                var secondPoint = Input.mousePosition;
                _delta = secondPoint.x - _firstPos.x;
                var pos = Mathf.Clamp(_delta, -maxHorizontal, maxHorizontal);
                Vector3 target = new Vector3(pos, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, controlSpeed * Time.deltaTime);


            }
            if (Input.GetMouseButtonUp(0))
            {
                _delta = 0;
            }


        }

        #endregion
    }

}
