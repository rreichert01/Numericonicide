using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerc : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject playeric2; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.gravityScale = 1f;
        
        rb.bodyType = RigidbodyType2D.Kinematic;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            Instantiate(playeric2, collision.transform.position, Quaternion.identity);
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
