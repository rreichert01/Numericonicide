using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playere : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.gravityScale = 1f;
        
        rb.bodyType = RigidbodyType2D.Kinematic;

        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
