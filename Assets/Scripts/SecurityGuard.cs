using UnityEngine;

public class SecurityGuard : MonoBehaviour
{
    public Transform player;
    private float chaseSpeed = 8f;
    private float jumpForce = 16f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;

    // couldn't figure out animations in time, using placeholder for now
    // for animations   
    //public Animator animator;

    // for respawn mechanic
    public GameObject playerRef;
    //private GameObject securityGuard;
    public Transform playerRespawnPoint;
    public Transform securityRespawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //securityGuard = GetComponent<GameObject>();
    }

    void Update() 
    {
        // is security guard grounded?
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // player direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        // play begin and run animations
        //animator.SetBool("IsRunning", true);

        if (isGrounded)
        {
            // stop playing jump animation 
            //animator.SetBool("IsJumping", false);
           // animator.SetBool("IsRunning", true);

            rb.linearVelocity = new Vector2(direction * chaseSpeed, rb.linearVelocity.y);

            // check if obstacle is ahead
            RaycastHit2D obstacleAhead = Physics2D.Raycast(transform.position, transform.right, 3f, groundLayer);

            if (obstacleAhead.collider)
            {
                shouldJump = true;
            }
        }
    }

    private void FixedUpdate() 
    {   
        if (isGrounded && shouldJump)
        {
            shouldJump = false;

            // play jump animation
            //animator.SetBool("IsRunning", false);
            //animator.SetBool("IsJumping", true);

            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpForce;

            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    // when player wins, stop security from moving past exit door
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExitDoor")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    // respawn player and security guy to original positions to restart run
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef.transform.position = playerRespawnPoint.position;
            transform.position = securityRespawnPoint.position;
        }
    }
}
