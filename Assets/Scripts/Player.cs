
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System.Reflection;
using System;

public class Player : MonoBehaviour
{

    public float jumpForce = 8f;
    public float groundCheckDistance = .5f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool GameOver = false;
    //private bool boxDone = false;
    private float missileSpeed = 10;
    private bool isGrounded;
    public GameObject defaultGun;
    public GameObject upgradeGun;
    public float switchDistance = 5f;
    public int health; 
    public int maxHealth = 10; 
    //public Shooter bulletPrefab; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
        health = maxHealth; 
      
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Shoot(); 
        //}
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        Vector3 move = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                move.x -= moveSpeed * Time.deltaTime * 2;
            }
            else
            {
                move.x -= moveSpeed * Time.deltaTime;
            }
            transform.eulerAngles = new Vector3(0f, 180f, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                move.x += moveSpeed * Time.deltaTime * 2;
            }
            else
            {
                move.x += moveSpeed * Time.deltaTime;
            }
            transform.eulerAngles = Vector3.zero;
        }
        transform.position += move;

        if (!isGrounded && Input.GetKey(KeyCode.S))
        {
            Down();
        }
        if (Input.GetKeyDown(KeyCode.Q) && isCloseEnough())
        {

            SwitchHierarchiesAndPositions();

        }

    }

    public void SwitchHierarchiesAndPositions()
    {
        // Store the parent of defaultGun
        Transform parent1 = defaultGun.transform.parent;

        // Store the parent of upgradeGun
        Transform parent2 = upgradeGun.transform.parent;

        // Store the position of defaultGun
        Vector3 position1 = defaultGun.transform.position;

        // Store the position of upgradeGun
        Vector3 position2 = upgradeGun.transform.position;

        // Store the rotation of defaultGun
        Quaternion rotation1 = defaultGun.transform.rotation;

        // Store the rotation of upgradeGun
        Quaternion rotation2 = upgradeGun.transform.rotation;

        // Set defaultGun's parent to upgradeGun's parent
        defaultGun.transform.SetParent(parent2, true);

        // Set upgradeGun's parent to defaultGun's parent
        upgradeGun.transform.SetParent(parent1, true);

        // Set defaultGun's position and rotation to upgradeGun's original position and rotation
        defaultGun.transform.position = position2;
        defaultGun.transform.rotation = rotation2;

        // Set upgradeGun's position and rotation to defaultGun's original position and rotation
        upgradeGun.transform.position = position1;
        upgradeGun.transform.rotation = rotation1;
    }


    public bool isCloseEnough()
    {

        float distance = Vector3.Distance(defaultGun.transform.position, upgradeGun.transform.position);

        return distance < switchDistance;
    }
    //private void Shoot()
    //{
    //    var laser = Instantiate(bullet, transform.position + transform.up, Quaternion.identity);
    //    laser.GetComponent<Rigidbody2D>().velocity = transform.up * missleSpeed;
    //}

    private void Jump()
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        private void Down()
        {
            rb.velocity = Vector2.down * jumpForce;
        }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount; 
        if(health <= 0){
            Destroy(gameObject); 
        }
    }


}
