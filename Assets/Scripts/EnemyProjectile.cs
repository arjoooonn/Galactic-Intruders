using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Ensure the counter doesn't go negative
        ProjectileSpawner.activeEnemyProjectiles = Mathf.Max(0, ProjectileSpawner.activeEnemyProjectiles - 1);
    }
}

