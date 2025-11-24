using UnityEngine;

public class PlayerMoveRB : MonoBehaviour
{

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement
        float move = 0f;
        if (Input.GetKey(left)) move = -moveSpeed;
        if (Input.GetKey(right)) move = moveSpeed;

        rb.linearVelocity = new Vector2(move, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Simple ground check
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}


