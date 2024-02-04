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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }
       
        if (IsOnTopOfObject())
        {
            Jump();
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

    public bool IsOnTopOfObject()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, groundCheckDistance, Physics.AllLayers);
        return hit.Length > 2;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
