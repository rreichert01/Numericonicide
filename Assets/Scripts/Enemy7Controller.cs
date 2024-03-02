using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7Controller : MonoBehaviour
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
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Player playerScript;
    
    private bool betrayed = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Betray()
    {
        betrayed = true; 
    }
    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Player"))
        // {
        //     if (betrayed)
        //     {
        //         DropWeapon(); 
        //     }
        // }
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
