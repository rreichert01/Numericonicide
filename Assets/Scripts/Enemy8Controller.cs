using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8Controller : MonoBehaviour
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
    public float pullForce = 10f; 
    public float pullRadius = 5f; 
    //public LayerMask pullLayers; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        isGrounded = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        isDetected();
        
    }

    public void isDetected()
    {
        detectedPlayer = Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < detectionDistance ? true : false;
        // if (detectedPlayer)
        // {
        //     ApplyGravitationalPull(); 
        // }
    }

    // void ApplyGravitationalPull()
    // {

    //     void ApplyGravitationalPull()
    //     {
    //         Vector2 direction = (transform.position - player.transform.position).normalized;
    //         player.GetComponent<Rigidbody2D>().AddForce(direction * gravityForce * Time.deltaTime);
    //     }

    //     // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pullRadius, pullLayers);

    //     // foreach (Collider2D collider in colliders)
    //     // {
    //     //     Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
    //     //     if (rb != null)
    //     //     {
    //     //         Vector2 direction = (transform.position - collider.transform.position).normalized;
    //     //         rb.AddForce(direction * gravityForce * Time.deltaTime);
    //     //     }
    //     // }
    // }


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

    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D otherRigidbody = other.attachedRigidbody;
        if (otherRigidbody != null && other.gameObject == player)
        {
            otherRigidbody.gravityScale = 0;

            Vector2 direction = (Vector2)transform.position - otherRigidbody.position;
            otherRigidbody.AddForce(direction.normalized * pullForce);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D otherRigidbody = other.attachedRigidbody;
        if (otherRigidbody != null && other.gameObject == player)
        {
            otherRigidbody.gravityScale = 1; 
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
