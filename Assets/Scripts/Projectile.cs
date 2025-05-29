using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosionPrefab;
    private PointManager pointManager;
    private Health health;
    private Marax marax;


    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Marax"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Marax enemyHealth = collision.gameObject.GetComponent<Marax>();
            if (enemyHealth != null)
            {
                enemyHealth.UpdateHealth(7);
                if (enemyHealth.HealthPoints <= 0)
                {
                    Destroy(collision.gameObject);
                    pointManager.UpdateScore(100); // Optional: score for BEnemy
                }
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Marax2"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Marax enemyHealth = collision.gameObject.GetComponent<Marax>();
            if (enemyHealth != null)
            {
                enemyHealth.UpdateHealth(7);
                if (enemyHealth.HealthPoints <= 0)
                {
                    Destroy(collision.gameObject);
                    pointManager.UpdateScore(100); // Optional: score for BEnemy
                }
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Health bossHealth = collision.gameObject.GetComponent<Health>();
            if (bossHealth != null)
            {
                bossHealth.UpdateBossHealth(5);
                if (bossHealth.Bosshealth <= 0)
                {
                    Destroy(collision.gameObject);
                    pointManager.UpdateScore(1000); // Optional: score for Boss
                }
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

}

