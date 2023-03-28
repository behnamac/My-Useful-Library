using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConstuctorExample
{
    public string name;
    public string sex;
    public int age;
    public float tall;

    public ConstuctorExample(string name, string sex, int age, float tall)
    {
        this.name = name;
        this.sex = sex;
        this.age = age;
        this.tall = tall;
    }

    public ConstuctorExample(string name)
    {
        this.name = name;        
    }

    public ConstuctorExample(string name, string sex)
    {
        this.name = name;
        this.sex = sex;
    }

    public ConstuctorExample(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
