using UnityEngine;
using System.Collections;

public class Enemy2Controller : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2.5f;
    public float attackRange = 2.5f;
    public int health = 2;
    public int damage = 2; 
    private Rigidbody2D rb;
    private Vector2 movement;
    public float groundCheckDistance = 1.5f;
    public float jumpForce = 5f;
    private float jumpCooldown = .5f; 
    private float lastJumpTime;
    private bool detectedPlayer = false;
    public float detectionDistance = 18f;
    public GameObject player;
    public Player playerScript;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        isGrounded = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
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
       
        if (isGrounded && Time.time - lastJumpTime > jumpCooldown && detectedPlayer)
        {
            Jump();
            lastJumpTime = Time.time; 
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
        Vector2 newVelocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        rb.velocity = newVelocity;
    }

    void AttackPlayer()
    {
        //Destroy(Player.gameObject);
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {   
            isGrounded = true;
        }

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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isGrounded = false;
        }

    }

    void HandleAttack(GameObject bullet)
    {
        Destroy(bullet);
        if (--health <= 0) 
        { 
            Destroy(gameObject);
            return;
        }
        StartCoroutine(ChangeColorCoroutine(Color.red, 0.2f));
    }

    IEnumerator ChangeColorCoroutine(Color newColor, float duration)
    {
        // Change the color to the new color
        spriteRenderer.color = newColor;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Change the color back to the original color
        spriteRenderer.color = originalColor;
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}
