using UnityEngine;
using UnityEngine.Events;

public class GiantPlugMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public bool grounded = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        grounded = IsGrounded();

        // play run animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal * speed));

        // don't have isFacing check because no asymmetrical animations

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
