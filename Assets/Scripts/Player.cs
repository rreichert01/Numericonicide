
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

     private bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
      
    }

    void Update()
    {
        if (isGrounded  && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Vector3 move = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x += moveSpeed * Time.deltaTime;
        }
        transform.position += move;
       
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
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
