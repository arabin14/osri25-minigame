using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // for respawn
    //public GameObject playerRef;
    //public Transform playerRespawnPoint;
    

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        Flip();
    }

    private bool IsGrounded() 
    {
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExitDoor")
        {
            Debug.Log("You made it!");
        }
    }

    /*private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Security"))
        {
            transform.position = playerRespawnPoint.position;
        }
    }*/
}
