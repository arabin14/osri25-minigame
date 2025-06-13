using UnityEngine;

public class SecurityGuard : MonoBehaviour
{
    [SerializeField] private float securityGuardSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Transform player;
    private Vector2 moveDirection;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
       //rb.transform.position = Vector2.MoveTowards(rb.transform.position, player.transform.position, securityGuardSpeed * Time.deltaTime);

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
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * securityGuardSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // maybe use range to plan ahead for jumping over obstacles

        if (collision.tag == "Player")
        {
            // option to restart run
        }
        else if (collision.tag == "Obstacle")
        {
            // jump over 
        }
    }
}
