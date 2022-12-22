using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // the enemy prefab to spawn
    public float spawnInterval = 1f; // the interval at which to spawn enemies, in seconds
    public Transform spawnPoint; // the position at which to spawn enemies

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnInterval); // start spawning enemies at a regular interval
    }

    void SpawnEnemy()
    {
        // instantiate an enemy at the spawn point
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
