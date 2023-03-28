using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NursePower
{
public enum CameraState
{
    gameplay,
    postLevel,
    nullMode
}

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public CameraState cameraState = CameraState.gameplay;

    [SerializeField] private Transform target;

    [SerializeField] private float cameraSpeed = 3f;

    [SerializeField] CameraSetting[] cameras;
    private Dictionary<string, CameraSetting> cameradic;

    private Vector3 _pos;
    private Vector3 _rot;
    private Camera cam;


    private void Awake()
    {
        Instance = this;

        cameradic = new Dictionary<string, CameraSetting>();

        for (int i = 0; i < cameras.Length; i++)
        {
            cameradic.Add(cameras[i].name, cameras[i]);
        }
        cam = Camera.main;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraState == CameraState.nullMode) return;

        if (cameraState == CameraState.gameplay)
        {
            if (target == null) return;
            transform.position = Vector3.Lerp(transform.position, target.position, cameraSpeed * Time.deltaTime);

        }
        else if (cameraState == CameraState.postLevel)
        {
            target = null;
            SetCamera("PostLevel");
            cameraState = CameraState.nullMode;

        }
     
    }

    public void SetCamera(string name)
    {

        StartCoroutine(SetCameraCO(name));
    }

    private IEnumerator SetCameraCO(string name)
    {
        _pos = cameradic[name].pos;
        _rot = cameradic[name].rot;
        while (cam.transform.localPosition != _pos || cam.transform.localEulerAngles != _rot)
        {
            yield return new WaitForEndOfFrame();
            cam.transform.localPosition = Vector3.MoveTowards(cam.transform.localPosition, _pos, 5 * Time.deltaTime);
            Quaternion r = Quaternion.Euler(_rot.x, _rot.y, _rot.z);
            cam.transform.localRotation = Quaternion.RotateTowards(cam.transform.localRotation, r, 100 * Time.deltaTime);
        }
        cameraState = CameraState.nullMode;
    }

}
[System.Serializable]
public class CameraSetting
{
    public string name;
    public Vector3 pos;
    public Vector3 rot;
}
}
