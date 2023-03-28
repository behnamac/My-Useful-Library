using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
    public int Health { get; set;}


    public int Damage(int value)
    {
        Health -= value;
        print(Health);
        return Health;

    }
}

