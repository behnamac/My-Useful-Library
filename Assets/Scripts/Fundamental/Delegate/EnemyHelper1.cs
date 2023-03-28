using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelper1 : MonoBehaviour
{
    [HideInInspector] public EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth=GetComponent<EnemyHealth>(); 
    }
    private void Awake()
    {
        DelegateTest.onEnemyCalled += OnHelp;
        Destroy(gameObject, 2);

    }

    private void OnDisable()
    {
        DelegateTest.onEnemyCalled -= OnHelp;

    }

    void OnHelp()
    {
        print("I'm Coming");
    }
}
