using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Controller : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 1.5f;
    public float attackRange = 2.5f;
    public int health = 5;
    public int damage = 5; 
    private Rigidbody2D rb;
    private Vector2 movement;
    public float groundCheckDistance = 1f;
    private bool detectedPlayer = false;
    public float detectionDistance = 18f;
    public GameObject player;
    public Player playerScript;
    public float spawnRadius = 10f; 
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isGrounded;
    private float followDuration = 5f; 
    private float roamDuration = 5f; 
    private float lastActionTime = 5f; 
    private float changePositionInterval = 5f; 
    private float lastPositionChangeTime; 
    public startCutscene cutscenescript; 

    
    // Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        float delay = Random.Range(0f, 7f); 
        InvokeRepeating("ChangePosition", delay, changePositionInterval);

    }

    // Update is called once per frame

    void Update()
    {
        isDetected();

        

        if (!startCutscene.isCutsceneOn)
        {
            Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
            movement = direction;
            if (Vector3.Distance(transform.position, Player.position) < attackRange)
            {
                AttackPlayer();
                }
        }
        else 
        {
            Freeze();
        
        }
        

    }

    void AttackPlayer()
    {
       // Destroy(Player.gameObject);
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

    void ChangePosition()
    {
        if (detectedPlayer)
        {
            Vector3 newPosition = GetRandomSpawnPosition();
            transform.position = newPosition;
        }
    }


    public bool IsOnTopOfObject()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, groundCheckDistance, Physics.AllLayers);
        return hit.Length > 2;
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

    private Vector3 PositionAwayFromPlayer()
    {
        float RandomX = player.transform.position.x + Random.Range(-20, 30); 
        float yPosition = player.transform.position.y + Random.Range(0, 10); 
        Vector3 spawnPosition = new Vector3(RandomX, yPosition, 0f); 

        return spawnPosition; 
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = player.transform.position.x + Random.Range(-spawnRadius, spawnRadius);
        float yPosition = player.transform.position.y - 1f; 

        //Vector2 randomOffset = Random.insideUnitCircle * spawnRadius; 
        Vector3 spawnPosition = new Vector3(randomX, yPosition, 0f); 

        return spawnPosition; 
    }

    public void Freeze()
    {
        rb.velocity = Vector2.zero; 
    }

    // public void Unfreeze()
    // {
    //     if (startCutscene.isCutsceneOn == false)
    //     {
    //         Debug.Log("back to it");
    //         gameObject.SetActive(true); 
    //     }
    // }


    
    
}
