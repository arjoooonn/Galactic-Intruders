using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectile;
    public float spawnTimer;
    public float spawnMax = 10;
    public float spawnMin = 5;

    public static int activeEnemyProjectiles = 0;
    public static int maxProjectilesAllowed = 5;

    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && activeEnemyProjectiles < maxProjectilesAllowed)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            activeEnemyProjectiles++;
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}
