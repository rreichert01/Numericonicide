
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class Player : MonoBehaviour
{

    public float jumpForce = 8f;
    public float groundCheckDistance = .5f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool GameOver = false;
    private bool boxDone = false;
    private float missileSpeed = 10;
    private bool isGrounded;
    //public Shooter bulletPrefab; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
      
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Shoot(); 
        //}
        if (isGrounded  && Input.GetKeyDown(KeyCode.W))
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
  
}
