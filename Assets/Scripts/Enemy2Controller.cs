using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2.5f;
    public float attackRange = 2.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float groundCheckDistance = 1.5f;
    public float jumpForce = 5f;
    private float jumpCooldown = .5f; 
    private float lastJumpTime;
    

    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        isGrounded = false;
    }

    void Update()
    {
        Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }
       
        if (isGrounded && Time.time - lastJumpTime > jumpCooldown)
        {
            Jump();
            lastJumpTime = Time.time; 
        }
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
        
    }

    void MoveEnemy(Vector2 direction)
    {
        Vector2 newVelocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        rb.velocity = newVelocity;
    }

    void AttackPlayer()
    {
        //Destroy(Player.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {   
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

}
