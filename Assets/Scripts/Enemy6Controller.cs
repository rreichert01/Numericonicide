using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Controller : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2.5f;
    public float attackRange = 2.5f;
    public int health = 6;
    public int damage = 6; 
    private Rigidbody2D rb;
    private Vector2 movement;
    //public float groundCheckDistance = 1.5f;
    //public float jumpForce = 5f;
    //private float jumpCooldown = .5f; 
    private float lastJumpTime;
    private bool detectedPlayer = false;
    public float detectionDistance = 18f;
    public GameObject player;
    public Player playerScript;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float verticalRange = 2.0f; 
    private float originalY; 
    private bool movingUp = true; 
    private bool isGrounded; 
    private bool hasFlipped = false; 
    private Vector3 healthOneposition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        isGrounded = false; 
        originalY = transform.position.y; 
        
    }

    // Update is called once per frame
    void Update()
    {
        //isDetected();
        MoveVertically(); 

        Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }
        if (transform.position.y >= originalY + verticalRange)
        {
            movingUp = false; 
        }
        else if (transform.position.y <= originalY - verticalRange)
        {
            movingUp = true; 
        }

        //healthOneposition = transform.position; 

        if (health == 1 && !hasFlipped)
        {
            
            Flip(); 
            //healthOneposition += new Vector3(-1.3f, -3f, 0f); 
            //transform.position = healthOneposition; 
            //transform.position = healthOneposition; 
            //Vector3 newPosition = new Vector3(transform.position.x - 1.3f, transform.position.y - 2f, transform.position.z);
            //transform.position = healthOneposition; 
        }
        
    }


    // void FixedUpdate()
    // {
    //     if (detectedPlayer) 
    //     {
    //         //MoveEnemy(movement); 
            
    //     }
         
    // }

    void Flip() 
    {

        Vector3 currentPosition = transform.position;

        // Flip the scale
        transform.localScale = new Vector3(-transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    
        // Calculate the position adjustment based on the change in scale
        float positionAdjustmentX = (transform.localScale.x > 0) ? 1.3f : -1.3f; // Adjust as needed
        float positionAdjustmentY = 2f; // Adjust as needed

        // Apply the position adjustment
        Vector3 newPosition = new Vector3(currentPosition.x + positionAdjustmentX, currentPosition.y - positionAdjustmentY, currentPosition.z);
        transform.position = newPosition;

        hasFlipped = true; 
    }   
        //Vector3 currentPos = transform.position; 

    //     transform.localScale = new Vector3(-transform.localScale.x, -transform.localScale.y , transform.localScale.z);
        
    //     // Vector3 newPosition = new Vector3(transform.position.x - 1.3f, transform.position.y - 1.5f, transform.position.z);
    //     // transform.position = newPosition;

    //     hasFlipped = true; 
    // }

    public void isDetected()
    {
        detectedPlayer = Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < detectionDistance ? true : false;
        
    }

    void MoveVertically()
    {
        float verticalMovement = movingUp ? moveSpeed : -moveSpeed;
        rb.velocity = new Vector2(rb.velocity.x, verticalMovement); 
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

}
