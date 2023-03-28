using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetChildComponentTest : MonoBehaviour
{
    [SerializeField] private Image bar;
    // Start is called before the first frame update
    void Start()
    {
        bar =GetComponentsInChildren<Image>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
