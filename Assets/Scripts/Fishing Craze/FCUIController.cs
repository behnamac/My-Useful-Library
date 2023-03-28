using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCUIController : MonoBehaviour
{
    public static FCUIController Instance;
    [SerializeField] private GameObject joyStick;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;


    }
    void Start()
    {
        Invoke(nameof(setActiveJoyStick), 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void setActiveJoyStick()
    {
        joyStick.gameObject.SetActive(true);

    }
}
