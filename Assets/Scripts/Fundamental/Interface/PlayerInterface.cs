using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour, InterfaceTest
{
    public float speed;
    public void Damage()
    {
        print("damage");
    }

    public void Heal()
    {
        print("Heal");
    }

    public void Level()
    {
        print("Level");
    }

    void Start()
    {
        Damage();
        Heal();
        Level();


    }
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed*Time.deltaTime);
    }


}
