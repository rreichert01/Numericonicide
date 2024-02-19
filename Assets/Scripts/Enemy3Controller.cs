using System.Diagnostics;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    
    public float moveSpeed = 1.5f;
    public float attackRange = 2.5f;
    public int health = 1;
    public int damage = 1; 
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject projectilePrefab;
    public float dropInterval = 3f; 
    private float nextDropTime = 3f;
    private bool movingRight = true;
    public float movementDistance = 10f; 
    private float startingXPosition;
   
    public Player playerScript;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingXPosition = transform.position.x; 
        dropInterval = Random.Range(2f, 4f);
        nextDropTime = Time.time + dropInterval; 
         
    
    }

    void Update()
    {
        MoveBackAndForth();
        DropProjectile();
    }
    void MoveBackAndForth()
    {
        float rightLimit = startingXPosition + movementDistance;
        float leftLimit = startingXPosition - movementDistance;
        if (movingRight && transform.position.x >= rightLimit)
        {
            movingRight = false;
        }
        else if (!movingRight && transform.position.x <= leftLimit)
        {
            movingRight = true;
        }

        float moveDirection = movingRight ? 1 : -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }


     void DropProjectile()
    {
        if (Time.time >= nextDropTime)
        {
            Vector3 spawnPosition = transform.position + new Vector3(-.8f, -.3f, 0); 
            //Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            GameObject projectileInstance = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
            nextDropTime = Time.time + dropInterval;
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
    }


}
