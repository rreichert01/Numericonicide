using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            Destroy(gameObject);
        }

    }

    void OnBecameInvisible()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }
}
