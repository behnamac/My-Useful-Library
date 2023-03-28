using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUITest : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(100, 90, 500, 1000), "menu");
        if (GUI.Button(new Rect(250, 300, 200, 50), "play"))
            Debug.Log("button pressed");
    }
}
