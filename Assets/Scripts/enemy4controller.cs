using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4controller : MonoBehaviour
{
    public Transform Player;
    //public float moveSpeed = 1.5f;
    public float attackRange = 2.5f;
    public int health = 4;
    public int damage = 4; 
    public Sprite lowHealthSprite1;
    public Sprite lowHealthSprite2;  
    private Rigidbody2D rb;
    //private Vector2 movement;
    public float groundCheckDistance = 1f;
    private bool detectedPlayer = false;
    public float detectionDistance = 8f;
    public GameObject player;
    public Player playerScript;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool hasSplit = false; 
    
     

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        isDetected();

        // Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        // movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }
        if (health == 1 && !hasSplit)
        {
            SplitSprite(); 
            hasSplit = true; 
        }
    }

    void FixedUpdate()
    {
        //if (detectedPlayer) { MoveEnemy(movement); }

    }

    public void isDetected()
    {
        detectedPlayer = Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < detectionDistance ? true : false;

    }

    void SplitSprite()
    {
        spriteRenderer.sprite = lowHealthSprite1; 
        GameObject newEnemy = new GameObject(); 
        newEnemy.AddComponent<SpriteRenderer>().sprite = lowHealthSprite2; 
        Vector3 scale = transform.localScale/ 6f; 
        newEnemy.transform.localScale = scale; 
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
        StartCoroutine(ChangeColorCoroutine(Color.red, 0.2f));
    }

    IEnumerator ChangeColorCoroutine(Color newColor, float duration)
    {
        spriteRenderer.color = newColor;
        yield return new WaitForSeconds(duration);
        spriteRenderer.color = originalColor;
    }
    


}