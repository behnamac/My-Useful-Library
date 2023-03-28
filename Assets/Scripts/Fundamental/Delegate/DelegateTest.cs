using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    public static DelegateTest Instance;

    public delegate void OnEnemyHandler();
    public static OnEnemyHandler onEnemyCalled;

    [SerializeField] private EnemyHelper targetEnemy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        targetEnemy = FindObjectOfType<EnemyHelper>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetEnemy.enemyHealth.Damage(20);
            if (targetEnemy.enemyHealth.Health<=0)
            {
                onEnemyCalled?.Invoke();
            }
        }
    }
}
