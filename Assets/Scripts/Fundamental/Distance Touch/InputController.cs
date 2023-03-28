using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DistanceTouch
{
    public class InputController : MonoBehaviour
    {
        Camera _camera;
        [SerializeField] private GameObject model;
        [SerializeField] private DİstanceTouch distanceTouch;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            TouchInput();
        }

        private void TouchInput()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 firstP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.nearClipPlane);
                Vector3 lastP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.farClipPlane);
                Vector3 firstW = _camera.ScreenToWorldPoint(firstP);
                Vector3 LastW = _camera.ScreenToWorldPoint(lastP);
                Ray ray = new Ray(firstW, LastW - firstW);
                RaycastHit hit;
                IstantiateObject(ray, out hit);

            }
        }

        private void IstantiateObject(Ray ray, out RaycastHit hit)
        {
            if (!Physics.Raycast(ray, out hit) || !distanceTouch.calculateTouch(hit.point)) return;
            //print(distanceTouch.calculateTouch(hit.point));
            //Debug.DrawRay(ray.origin, -hit.point, Color.blue);
            distanceTouch._touch = hit.point;
            Instantiate(model, hit.point, Quaternion.identity);

        }
    }

}
