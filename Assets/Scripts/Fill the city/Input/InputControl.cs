using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FillTheCity
{
    public class InputControl : MonoBehaviour
    {
        private bool _hasHit;
        private RaycastHit _raycastHit;
        #region Unity Methods

        private void Update() => checkTouchState();

        #endregion

        private void checkTouchState()
        {
            if (Input.GetMouseButtonDown(0))
                OnTouchDown();
            if (Input.GetMouseButton(0))
                OnTouch();
            if (Input.GetMouseButtonUp(0))
                OnTouchUp();
        }

        public void OnTouchDown()
        {
            checkRaycast(out _hasHit, out _raycastHit);
            if (!_hasHit) return;
            if (!_raycastHit.transform.TryGetComponent(out ITouchable field)) return;
            field.OnTouchDown(_raycastHit.point);
        }


        public void OnTouch()
        {
            checkRaycast(out _hasHit, out _raycastHit);
            if (!_hasHit) return;
            if (!_raycastHit.transform.TryGetComponent(out ITouchable field)) return;
                field.OnTouch(_raycastHit.point);
        }

        public void OnTouchUp()
        {
            checkRaycast(out _hasHit, out _raycastHit);
            if (!_hasHit) return;
            if (!_raycastHit.transform.TryGetComponent(out ITouchable field)) return;
                field.OnTouchUp(_raycastHit.point);
        }



        private void checkRaycast(out bool hasHit, out RaycastHit raycastHit)
        {
            Camera cam = Camera.main;
            Vector3 pointNearCam = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
            Vector3 pointFarCam = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
            Vector3 StartPoint = cam.ScreenToWorldPoint(pointNearCam);
            Vector3 EndPoint = cam.ScreenToWorldPoint(pointFarCam);

            Ray ray = new Ray(StartPoint, EndPoint - StartPoint);
            bool hit = Physics.Raycast(ray, out raycastHit);
            hasHit = hit;
        }

        #region Draw Ray
        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.red;
        //    Camera cam = Camera.main;
        //    Vector3 pointNearCam = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
        //    Vector3 pointFarCam = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
        //    Vector3 StartPoint = cam.ScreenToWorldPoint(pointNearCam);
        //    Vector3 EndPoint = cam.ScreenToWorldPoint(pointFarCam);
        //    Gizmos.DrawRay(StartPoint, EndPoint - StartPoint);
        //}
        #endregion
    }
}
