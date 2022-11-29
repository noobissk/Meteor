using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int MaxHealth, EnemyId;
    public float health;
    void Start()
    {
        health = MaxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            if (EnemyId == 0)
            {
                SpawnEnemies.currentEnemies[0] -= 1;
            }
            else if (EnemyId == 1)
            {
                SpawnEnemies.currentEnemies[1] -= 1;
            }
            Destroy(gameObject);
        }
    }
}
