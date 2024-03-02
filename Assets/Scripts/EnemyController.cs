using System.Diagnostics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 1.5f;
    public float attackRange = 2.5f;
    public int health = 1;
    public int damage = 1; 
    private Rigidbody2D rb;
    private Vector2 movement;
    public float groundCheckDistance = 1f;
    private bool detectedPlayer = false;
    public float detectionDistance = 18f;
    public GameObject player;
    public Player playerScript;
     

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // player = GameObject.FindWithTag("Player"); 
        // if (player != null)
        // {
        //     playerScript = player.GetComponent<Player>(); 

        //}
    }

    void Update()
    {
        isDetected();

        Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }
    }

    void FixedUpdate()
    {
        if (detectedPlayer) { MoveEnemy(movement); }

    }

    public void isDetected()
    {
        detectedPlayer = Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < detectionDistance ? true : false;

    }

    void MoveEnemy(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }

    void AttackPlayer()
    {
       // Destroy(Player.gameObject);
    }

    public bool IsOnTopOfObject()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, groundCheckDistance, Physics.AllLayers);
        return hit.Length > 2;
    }

    private void Jump()
    {
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }         
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HandleAttack(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if(playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
             
        }
    }

    void HandleAttack(GameObject bullet) 
    {
        Destroy(bullet);
        if (--health <= 0) { Destroy(gameObject);}
    }


}