using UnityEngine;

public class SecurityGuard : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float chaseSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        // is security guard grounded?
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // player direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        if (isGrounded)
        {
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
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpForce;

            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExitDoor")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            //float direction = Mathf.Sign(player.position.x - transform.position.x);
            //rb.linearVelocity = new Vector2((direction * -1) * 1f, rb.linearVelocity.y);
        }
    }

    /*private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        // if player is found
        if (player) 
        {
            Vector3 direction = (player.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    private void FixedUpdate() 
    {
        if (player)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * chaseSpeed;
        }
    }*/
}
