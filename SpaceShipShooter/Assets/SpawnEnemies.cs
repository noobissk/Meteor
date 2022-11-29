using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Basic Enemy")]
    [SerializeField] Transform[] EnemySpawnPoints;
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] float BasicEnemySpawnInterval = 3.5f, BigEnemySpawnInterval = 8;
    [SerializeField] int[] MaxEnemies;
    static public int[] currentEnemies;

    void Start()
    {
        currentEnemies = new int[2];
        StartCoroutine(spawnEnemy(BasicEnemySpawnInterval, EnemyPrefabs[0], 0));
        StartCoroutine(spawnEnemy(BigEnemySpawnInterval, EnemyPrefabs[1], 1));
    }

    IEnumerator spawnEnemy(float interval, GameObject Enemy, int EnIdentification)
    {
        yield return new WaitForSeconds(interval);
        int randSpawnPoint = Random.Range(0, EnemySpawnPoints.Length);

        
        if (MaxEnemies[EnIdentification] > currentEnemies[EnIdentification])
        {
            Instantiate(Enemy, EnemySpawnPoints[randSpawnPoint].position, transform.rotation);
            currentEnemies[EnIdentification]++;
        }
        StartCoroutine(spawnEnemy(interval, Enemy, EnIdentification));
    }
}
