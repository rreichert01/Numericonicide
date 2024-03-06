using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Enemy8Controller : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2.5f;
    public float attackRange = 2.5f;
    public int health = 8;
    public int damage = 8; 
    private Rigidbody2D rb;
    private Vector2 movement;
    private float lastJumpTime;
    private bool detectedPlayer = false;
    public float detectionDistance = 18f;
    public GameObject player;
    public Player playerScript;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float influenceRange; 
    public float intensity; 
    public float distanceToPlayer; 
    private bool isGrounded; 
    Vector2 pullForce;  
    Rigidbody2D playerBody;
    public Transform enemy7; 
    public Enemy7Controller enemy7script; 
    public float enhancementDuration = 60f;
    private bool enhanced = false; 
    private bool destroyed = false; 
    private bool enemy7Destroyed = false;  
    
    // [SerializeField] private TMP_Text text; 

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>(); 
        playerBody = Player.GetComponent<Rigidbody2D>(); 
        isGrounded = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        
        //StartCoroutine(EnhanceEnemy()); 

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToPlayer = Player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        if (distanceToPlayer <= detectionDistance)
        {
            float horizontalPull = directionToPlayer.normalized.x * intensity / distanceToPlayer;
            float verticalPull = directionToPlayer.normalized.y * intensity / distanceToPlayer * 0.5f;
            playerBody.AddForce(new Vector2(-horizontalPull, -verticalPull), ForceMode2D.Force) ;
        }

        if (enemy7 == null && !enemy7Destroyed)
        {
            enemy7Destroyed = true; 
            StartCoroutine(EnhancementTimer());
        }

        

        
        
    }

    IEnumerator EnhancementTimer()
    {
        yield return new WaitForSeconds(enhancementDuration);

        // Check if enemy8 is still alive and not already enhanced
        if (!destroyed && !enhanced)
        {
            EnhanceEnemy();
        }
    }

    void EnhanceEnemy()
    {

        
        transform.Rotate(0, 0, -90);
        Vector3 newPosition = transform.position;
        newPosition += new Vector3(-3, -3, 0);
        transform.position = newPosition;
        transform.localScale *= 5;
        health = 8;
        intensity = 80;
        enhanced = true; // Set flag to true to prevent multiple enhancements
    }

    void OnDestroy()
    {
        destroyed = true;
    }



    // public void isDetected()
    // {
    //     detectedPlayer = Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < detectionDistance ? true : false;
        
    // }


    void AttackPlayer()
    {
        //Destroy(Player.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(4);
            Destroy(collision.gameObject);        
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HandleAttack(collision.gameObject); 
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

    // void StartEnhanceCoroutine()
    // {
    //     if(enemy7 == null && !enhanced)
    //     {
    //         StartCoroutine(EnhanceEnemy()); 
    //     }
    // }

    // IEnumerator EnhanceEnemy()
    // {
    //     yield return  new WaitForSeconds(60f);
    //     if (!destroyed)
    //     {
    //         transform.Rotate(0,0,-90); 
    //         Vector3 newPosition = transform.position;
    //         newPosition += new Vector3(-3, -3, 0); 
    //         transform.position = newPosition;
    //         transform.localScale *= 5; 
    //     }
    // }

}

