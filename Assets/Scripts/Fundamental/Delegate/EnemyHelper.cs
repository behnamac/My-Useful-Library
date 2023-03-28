using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using Levels;

[RequireComponent(typeof(Rigidbody))]

public class EnemyHelper : MonoBehaviour
{
    [HideInInspector]public EnemyHealth enemyHealth;
    Rigidbody mybody;
    // Start is called before the first frame update

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        mybody = GetComponent<Rigidbody>();
        enemyHealth.Health = 100;  
    }

    void Start()
    {

        DelegateTest.onEnemyCalled += OnHelp;
        LevelManager.OnLevelStart += (level) =>
        {
            PrintTest(level);
            loadUI();
        };

        LevelManager.Test+= (ff)=>        
        {
            for (int i = 0; i < 3; i++)
            {
            PrintTest2(ff);

            }
        };

        Invoke(nameof(Counter),2);


    }
    private void OnDisable()
    {
        DelegateTest.onEnemyCalled -= OnHelp;
        LevelManager.OnLevelStart -= (level) =>
        {
            PrintTest(level);
        };

    }

    void OnHelp()
    {
        mybody.AddForce(Vector3.up * 300);
    }

    private void loadUI()
    {

    }

    private void PrintTest(Level level)
    {
        print("new call");
    }
    private void PrintTest2(float  value)
    {
        print(value);
    }

    
    public void Counter(float value)
    {
        var sum = value++;
        print(sum);
    }
}
