using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObjectTest : MonoBehaviour
{
    float playerSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal"))>0)
        {
            transform.Translate(Vector3.left * Input.GetAxis("Horizontal") * playerSpeed*Time.deltaTime);
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);
        }
    }
}
