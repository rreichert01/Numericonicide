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
    public startCutscene cutscenescript; 
    public Transform invulnerable; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        invulnerable.gameObject.SetActive(false); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cutscenescript == null || !cutscenescript.isActiveAndEnabled)
        {
            Destroy(gameObject); 
            invulnerable.gameObject.SetActive(true); 
            StartTimer(); 
        }
        
    }

    void HandlePlayerCollision()
    {
        if (!startCutscene.isCutsceneOn)
        {
            Destroy(gameObject); 
            invulnerable.gameObject.SetActive(true); 
            StartTimer(); 
        }
    }

    void StartTimer()
    {
        if (timer != null)
        {
            timer.gameObject.SetActive(true); 
            timer.StartTimer(); 
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         HandlePlayerCollision(); // Call the method when the player enters the trigger
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Check if the colliding object has the tag "Bullet"
        // if (collision.gameObject.CompareTag("Bullet"))
        // {
        //     HandleAttack(collision.gameObject);
        // }
    }

    // void HandleAttack(GameObject bullet) 
    // {
    //     Destroy(bullet);
    //     if (--health <= 0) 
    //     { 
    //         Destroy(gameObject);
    //         //return;
    //         if (timer != null)
    //         {
    //             timer.gameObject.SetActive(true); 
    //             timer.StartTimer(); 
    //         }
    //         return; 
    //     }
    //     StartCoroutine(ChangeColorCoroutine(Color.red, 0.2f));
    // }
    
}
