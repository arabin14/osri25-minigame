using UnityEngine;

public class SelfPortraitMovement : MonoBehaviour
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

        animator.SetFloat("Speed", Mathf.Abs(horizontal * speed));

        if (!isFacingRight)
        {
            animator.SetBool("Direction", false);
        } else {
            animator.SetBool("Direction", true);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        Flip();
    }

    /*public void OnLanding() 
    {
        animator.SetBool("IsJumping", false);
    }*/

    private bool IsGrounded() 
    {
        animator.SetBool("IsJumping", false);
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
