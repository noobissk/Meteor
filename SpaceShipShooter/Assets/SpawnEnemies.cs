using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Basic Enemy")]
    [SerializeField] GameObject EnemyBasic;
    [SerializeField] int NumberOfEnemies1;
    int Enemy1Num;

    void Update()
    {

        if (Enemy1Num != NumberOfEnemies1)
        {
            Vector2 SpawnPos = new Vector2(Random.Range(-25, 25), Random.Range(-25, 25));
            Instantiate(EnemyBasic);
        }
    }
}
