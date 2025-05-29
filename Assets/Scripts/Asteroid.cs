using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] damageSprites; // Assign 6 sprites (index 0 = undamaged)
    private int hitCount = 0;
    private SpriteRenderer spriteRenderer;
    public GameObject explosionPrefab;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            hitCount++;

            int spriteIndex = hitCount / 5;

            if (spriteIndex < damageSprites.Length)
            {
                spriteRenderer.sprite = damageSprites[spriteIndex];
            }
            else
            {
                Destroy(gameObject); // Optional: trigger explosion effect instead
            }
        }
        if (other.CompareTag("EnemyProjectile"))
        {
            Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            hitCount++;

            int spriteIndex = hitCount / 5;

            if (spriteIndex < damageSprites.Length)
            {
                spriteRenderer.sprite = damageSprites[spriteIndex];
            }
            else
            {
                Destroy(gameObject); // Optional: trigger explosion effect instead
            }
        }
        if (other.CompareTag("Beam"))
        {
            Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            hitCount++;

            int spriteIndex = hitCount / 10;

            if (spriteIndex < damageSprites.Length)
            {
                spriteRenderer.sprite = damageSprites[spriteIndex];
            }
            else
            {
                Destroy(gameObject); // Optional: trigger explosion effect instead
            }
        }
    }
}


