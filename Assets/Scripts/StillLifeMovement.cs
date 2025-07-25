using UnityEngine;

public class StillLifeMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // for animations
    public Animator animator;
    public bool grounded = false;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();

        // play run animation 
        animator.SetFloat("Speed", Mathf.Abs(horizontal * speed));

        // asymmetrical animations based on direction
        if (!isFacingRight)
        {
            animator.SetBool("Direction", false);
        } else {
            animator.SetBool("Direction", true);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // play jump animation 
            animator.SetBool("IsJumping", true);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        Flip();
    }

    private bool IsGrounded() 
    {
        // stop playing jump animation 
        animator.SetBool("IsJumping", false);

        // check if player is touching the ground 
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate() 
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

    }

    // Flips the player in direction of movement
    private void Flip() 
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
