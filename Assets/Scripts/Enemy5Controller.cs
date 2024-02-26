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
    private float changePositionInterval = 5f; 
    private float lastPositionChangeTime; 

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

        Vector2 direction = new Vector2((Player.position.x - transform.position.x)/2, 0).normalized;
        movement = direction;

        if (Vector3.Distance(transform.position, Player.position) < attackRange)
        {
            AttackPlayer();
        }

        // if (Time.time - lastPositionChangeTime >= changePositionInterval){
        //     ChangePosition(); 
        //     lastPositionChangeTime = Time.time; 
        // }
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
        Vector3 newPosition = GetRandomSpawnPosition(); 
        transform.position = newPosition; 
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

    // IEnumerator SpawnEnemies()
    // {
    //     while (true){
    //         Vector3 spawnPosition = GetRandomSpawnPosition(); 
    //         Instantiate(enemy5Prefab, spawnPosition, Quaternion.identity);
    //         //SpawnEnemy(spawnPosition); 
    //         yield return new WaitForSeconds(spawnInterval); 
    //     }

    // }

    private Vector3 GetRandomSpawnPosition()
    {
        //Vector3 playerDirection = player.localScale.x > 0 ? Vector3.right : Vector3.left;
       // float randomX = player.position.x + Random.Range(0f, spawnRadius) * playerDirection.x; 
        float randomX = player.transform.position.x + Random.Range(-spawnRadius, spawnRadius);
        float yPosition = player.transform.position.y; 

        //Vector2 randomOffset = Random.insideUnitCircle * spawnRadius; 
        Vector3 spawnPosition = new Vector3(randomX, yPosition, 0f); 

        return spawnPosition; 
    }



}