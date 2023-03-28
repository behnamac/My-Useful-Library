using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FCStorage;

public enum InputType { touch, keyboard }

public class FCCharacterController : MonoBehaviour
{
    public static FCCharacterController Instance;
    /*[HideInInspector]*/
    public List<Transform> Collectable;
    [HideInInspector] public float CurrentSpeedForward;
    [HideInInspector] public int UpgradeNumber;

    [SerializeField] private InputType inputType;
    [SerializeField] private float speedForward = 5f;
    [SerializeField] Joystick joystick;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private Transform CollectablePoint;
    Vector3 firstPos;
    Quaternion firstRot;

    public bool canMove;
    float angularVelocity;
    float angularTime = 0.1f;


    private void Awake()
    {
        Instance = this;
        Initialized();


    }

    private void Start()
    {

        CurrentSpeedForward = FCPlayerPrefsController.Instance.GetPlayerSpeed();

    }

    private void Update()
    {
        if (!canMove) return;
        switch (inputType)
        {
            case (InputType.touch):
                Movement(joystick.Horizontal, joystick.Vertical);
                break;
            case (InputType.keyboard):
                Movement(Input.GetAxis("Horızontal"), Input.GetAxis("Vertical"));
                break;
        }
    }


    private void Movement(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        float move = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));
        if (move >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref angularVelocity, angularTime);
            transform.eulerAngles = new Vector3(0, angle, 0);
            if (isGrounded())
            {
                transform.Translate(0, 0, speedForward * Time.deltaTime);
            }
            //todo: play move animation

        }

    }

    private bool isGrounded()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + ((Vector3.up) + (transform.forward * 0.5f)), Vector3.down);
        if (Physics.Raycast(ray, out hit, 6, groundLayer))
        {
            return true;
        }
        return false;
    }

    public void upgradeSpeedMove(float velue)
    {
        CurrentSpeedForward += velue;
        FCPlayerPrefsController.Instance.SetPlayerSpeed(CurrentSpeedForward);
    }

    public void AddCollectable(Transform obj)
    {
        Collectable.Add(obj);
        obj.SetParent(CollectablePoint);
        obj.localRotation = Quaternion.Euler(obj.GetComponent<FCAutoCollectable>().Rotation);
        FCFormation.LineFormation(Collectable.ToArray(), Vector3.zero, WorldType.Local, Vector3.up, 0.002f);


    }


    private void Initialized()
    {
        UpgradeNumber = PlayerPrefs.GetInt("PlayerUpgradeNumber");
        canMove = true;
        Collectable = new List<Transform>();
        firstPos = transform.position;
        firstRot = transform.rotation;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + ((Vector3.up) + (transform.forward * 0.5f)), Vector3.down);
    }





}
