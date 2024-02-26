using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTrigger : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
       {
        UnityEngine.Debug.Log("HIT");
        UnityEngine.Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Player")
        {
            FindObjectOfType<HandleScene>().OpenLevel2Scene();
            UnityEngine.Debug.Log("Level 2 Open");
        }
    
      }
}
