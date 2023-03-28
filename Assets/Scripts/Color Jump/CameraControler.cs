using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorJump
{
    public class CameraControler : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] float cameraSpeed;
        [SerializeField] Vector3 offset;
        
        void LateUpdate()
        {
            cameraController();
        }

        void cameraController()
        {
            // var totalTarget = offset + target.position;
            transform.position = Vector3.Lerp(transform.position, target.position, cameraSpeed);
            Quaternion rot = Quaternion.Euler(0, target.transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 2 * Time.deltaTime);
        }
    }
}
