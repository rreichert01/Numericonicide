using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7Controller : MonoBehaviour
{
    public Transform Player;
    public float attackRange = 2.5f;
    public int health = 7;
    private Rigidbody2D rb;
    public float groundCheckDistance = 1f;
    private bool detectedPlayer = false;
    public float detectionDistance = 8f;
    public GameObject player;
    public Player playerScript;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Timer timer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
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
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         if(playerScript != null)
    //         {
    //             playerScript.TakeDamage(damage);
    //         }
             
    //     }
    }

    void HandleAttack(GameObject bullet) 
    {
        Destroy(bullet);
        if (--health <= 0) 
        { 
            Destroy(gameObject);
            //return;
            if (timer != null)
            {
                timer.gameObject.SetActive(true); 
                timer.StartTimer(); 
            }
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
