
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;
    public float groundCheckDistance = 1f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool GameOver = false;
    private bool boxDone = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    void Update()
    {
        UnityEngine.Debug.Log("Hello");
        if (!GameOver)
        {
            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);
            UnityEngine.Debug.Log(Input.GetAxis("Horizontal"));

            if (IsOnTopOfObject() && Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public bool IsOnTopOfObject()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, groundCheckDistance, Physics.AllLayers);
        return hit.Length > 2;
    }

  
}
