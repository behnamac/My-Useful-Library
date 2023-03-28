using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnumExample : MonoBehaviour
{
    EnumExample enumExample;
    // Start is called before the first frame update
    void Start()
    {
        enumExample = GetComponent<EnumExample>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var random = Random.Range(0, 6);
            enumExample.CurrentState = (EnumExample.state)(random);
            print(random);

        } 
    }
}
