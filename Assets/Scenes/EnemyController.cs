using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 1.5f;
    public float attackRange = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;

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
    }

    void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }

    void AttackPlayer()
    {
        // implement
    }
}
