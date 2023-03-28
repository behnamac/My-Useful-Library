using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumExample : MonoBehaviour
{
    public enum state
    {
        dead,
        alive,
        chase,
        heal,
        upgrade,
        win
    }

    public state CurrentState;
}
