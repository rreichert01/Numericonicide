using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalTrigger : MonoBehaviour
{
    public int nextScene;
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
            SceneManager.LoadScene(nextScene);
        }
    
      }
}
