using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Basic Enemy")]
    [SerializeField] Transform[] EnemySpawnPoints;
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] float EnemySpawnInterval = 3.5f;

    void Start()
    {
        StartCoroutine(spawnEnemy(EnemySpawnInterval));
    }

    IEnumerator spawnEnemy(float interval)
    {
        yield return new WaitForSeconds(interval);
        int randEnemy = Random.Range(0, EnemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, EnemySpawnPoints.Length);

        Instantiate(EnemyPrefabs[0], EnemySpawnPoints[randSpawnPoint].position, transform.rotation);
        StartCoroutine(spawnEnemy(interval));
    }
}
