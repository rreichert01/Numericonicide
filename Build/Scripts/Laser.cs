using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.collider.tag == "Platform")
        // {
        //     Destroy(gameObject);
        // }
        // if (collision.collider.tag == "enemybullet")
        // {
        //     Destroy(gameObject); 
        //     Destroy(collision.gameObject); 
        // }

        Destroy(gameObject);
        if (collision.collider.tag == "enemybullet")
        {
            Destroy(collision.gameObject); 
        }

    }
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.layer == 8)
    {
      
        Destroy(other.gameObject);

    
    }
}
    void Update()
    {
        
    }
}
