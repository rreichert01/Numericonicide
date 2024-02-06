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
    public LayerMask groundLayer;
    
    public bool isGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }
       
        if (isGrounded)
        {
            Jump();
            //Debug.Log("jump");
        }
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        Vector2 newPosition = new Vector2(transform.position.x + (direction.x * moveSpeed * Time.fixedDeltaTime), transform.position.y);
        rb.MovePosition(newPosition);
    }

    void AttackPlayer()
    {
        Destroy(Player.gameObject);
    }


    void OnCollisionEnter2D(Collision2D collision){
    if (collision.gameObject.name == "Ground"){
        isGrounded = true;
        }
    }   

    void OnCollisionExit2D(Collision2D collision){
    if (collision.gameObject.name == "Ground"){
        isGrounded = false;
    }
}

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
