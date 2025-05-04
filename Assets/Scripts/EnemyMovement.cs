using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float baseMoveInterval = 0.8f;    // Starting time between moves
    public float horizontalStep = 0.5f;      // Horizontal movement per step
    public float verticalStep = 0.4f;        // Vertical drop when changing direction
    public float speedIncreasePerKill = 0.02f;// Speed boost per destroyed enemy

    [Header("Screen Boundaries")]
    public float screenEdgePadding = 0.1f;   // 10% screen padding

    private bool movingRight = true;
    private float moveTimer = 0f;
    private int initialChildCount;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        initialChildCount = transform.childCount;
    }

    void Update()
    {
        moveTimer += Time.deltaTime;
        float currentMoveInterval = CalculateMoveInterval();

        if (moveTimer >= currentMoveInterval)
        {
            MoveFormation();
            moveTimer = 0f;
        }
    }

    float CalculateMoveInterval()
    {
        // Faster movement as enemies are destroyed
        float remainingEnemies = (float)transform.childCount / initialChildCount;
        return baseMoveInterval * Mathf.Clamp(remainingEnemies, 0.2f, 1f);
    }

    void MoveFormation()
    {
        // Calculate movement direction
        Vector3 moveDirection = movingRight ? Vector3.right : Vector3.left;
        transform.Translate(moveDirection * horizontalStep);

        // Check screen edges using camera viewport
        if (CheckScreenEdges())
        {
            // Descend and reverse direction
            transform.Translate(Vector3.down * verticalStep);
            movingRight = !movingRight;
        }
    }

    bool CheckScreenEdges()
    {
        foreach (Transform enemy in transform)
        {
            if (!enemy) continue; // Skip destroyed enemies

            Vector3 viewportPos = mainCamera.WorldToViewportPoint(enemy.position);
            bool atRightEdge = viewportPos.x > (1 - screenEdgePadding);
            bool atLeftEdge = viewportPos.x < screenEdgePadding;

            if ((movingRight && atRightEdge) || (!movingRight && atLeftEdge))
            {
                return true;
            }
        }
        return false;
    }

    // Visual debug for screen boundaries
    void OnDrawGizmosSelected()
    {
        if (!mainCamera) return;

        Gizmos.color = Color.red;
        Vector3 leftBound = mainCamera.ViewportToWorldPoint(new Vector3(screenEdgePadding, 0));
        Vector3 rightBound = mainCamera.ViewportToWorldPoint(new Vector3(1 - screenEdgePadding, 0));

        Gizmos.DrawLine(leftBound, leftBound + Vector3.up * 10);
        Gizmos.DrawLine(rightBound, rightBound + Vector3.up * 10);
    }
}