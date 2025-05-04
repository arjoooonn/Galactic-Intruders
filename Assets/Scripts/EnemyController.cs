// EnemyController.cs
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f;
    public float moveInterval = 0.5f;
    private bool movingRight = true;
    private float moveTimer = 0f;

    [Header("Shooting")]
    public GameObject enemyBulletPrefab;
    public float shootProbability = 0.001f; // Chance per frame

    void Update()
    {
        // Movement
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveInterval)
        {
            MoveAsGroup();
            moveTimer = 0f;
        }

        // Random Shooting
        if (Random.value < shootProbability)
        {
            Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void MoveAsGroup()
    {
        Vector2 moveDirection = movingRight ? Vector2.right : Vector2.left;
        transform.Translate(moveDirection * moveSpeed);

        // Screen edge check (attach this to EnemyWaveManager instead for better performance)
        foreach (Transform enemy in transform.parent)
        {
            if (enemy.position.x > 8f || enemy.position.x < -8f)
            {
                ReverseDirection();
                return;
            }
        }
    }

    void ReverseDirection()
    {
        movingRight = !movingRight;
        transform.Translate(Vector2.down * 0.5f); // Move down
    }
}