using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDistance = 10f;
    public float spawnRate = 2f;

    private float nextSpawnTime;
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    void SpawnEnemy()
    {
        Vector2 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPoint = transform.position + new Vector3(spawnDirection.x, spawnDirection.y, 0);
        
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }
}
