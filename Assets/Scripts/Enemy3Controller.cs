using System.Diagnostics;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
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
    }

    void Update()
    {
        isDetected();
        Vector2 direction = new Vector2(0, Mathf.Sign(Player.position.y - transform.position.y)).normalized;


        //Vector2 direction = new Vector2(0, (Player.position.y - transform.position.y)/2).normalized;
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

    // public void isDetected()
    // {
    //     detectedPlayer = Mathf.Abs(gameObject.transform.position.y - player.transform.position.y) < detectionDistance && Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < detectionDistance;
    // }


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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HandleAttack(collision.gameObject);
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