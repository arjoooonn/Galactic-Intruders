using UnityEngine;

public class MovementHorizontal : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalBoundary = 8f; // How far player can move left/right

    private float horizontalInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input (works with both keyboard and gamepad)
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // Calculate movement
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Apply movement
        rb.velocity = movement;

        // Clamp position to stay within boundaries
        float clampedX = Mathf.Clamp(rb.position.x, -horizontalBoundary, horizontalBoundary);
        rb.position = new Vector2(clampedX, rb.position.y);
    }
}