using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnDistance = 10f;
    [SerializeField] private float _spawnRate = 2f;

    private float _nextSpawnTime;
    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnRate;
        }
    }
    void SpawnEnemy()
    {
        Vector2 spawnDirection = Random.insideUnitCircle.normalized * _spawnDistance;
        Vector3 spawnPoint = transform.position + new Vector3(spawnDirection.x, spawnDirection.y, 0);
        
        Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
    }
}
