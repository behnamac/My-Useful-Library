using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelper2 : MonoBehaviour
{
    [HideInInspector] public EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        DelegateTest.onEnemyCalled += OnHelp;
    }
    private void OnDisable()
    {
        DelegateTest.onEnemyCalled -= OnHelp;

    }

    void OnHelp()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
