using UnityEngine;
using System.Collections;

public class PlayerMoveRB : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;

    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float crouchSpeedMultiplier = 0.4f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = false;
    private bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleCrouch();
        HandleMovement();
        HandleJump();
        DropDownPlatform();   
    }

    void HandleCrouch()
    {
        if (Input.GetKeyDown(crouch) && isGrounded)
        {
            isCrouching = true;
            anim.SetBool("isCrouching", true);
        }

        if (Input.GetKeyUp(crouch))
        {
            isCrouching = false;
            anim.SetBool("isCrouching", false);
        }
    }

    void HandleMovement()
    {
        float move = 0f;

        if (Input.GetKey(left)) move = -1f;
        if (Input.GetKey(right)) move = 1f;

        bool running = Input.GetKey(KeyCode.LeftShift) && !isCrouching;
        float finalSpeed = running ? runSpeed : walkSpeed;

        if (isCrouching)
            finalSpeed *= crouchSpeedMultiplier;

        rb.linearVelocity = new Vector2(move * finalSpeed, rb.linearVelocity.y);

        if (isCrouching)
        {
            anim.SetFloat("speed", 0f);
        }
        else
        {
            float animSpeed = Mathf.Abs(move) > 0 ?
                (running ? 1f : 0.5f) : 0f;
            anim.SetFloat("speed", animSpeed);
        }


        if (move < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (move > 0) transform.localScale = new Vector3(1, 1, 1);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(jump) && isGrounded && !isCrouching)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("isJumping", true);
        }
    }

    void DropDownPlatform()
    {
        if (isCrouching && Input.GetKeyDown(jump))
        {
            StartCoroutine(DisablePlatformCollision());
        }
    }

    IEnumerator DisablePlatformCollision()
    {
        Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("Player"),
            LayerMask.NameToLayer("OneWayPlatform"),
            true
        );

        yield return new WaitForSeconds(0.25f);

        Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("Player"),
            LayerMask.NameToLayer("OneWayPlatform"),
            false
        );
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") ||
            col.gameObject.CompareTag("OneWayPlatform"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") ||
            col.gameObject.CompareTag("OneWayPlatform"))
        {
            isGrounded = false;
        }
    }
}










