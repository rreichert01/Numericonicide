using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision)
        // {
        Destroy(gameObject);
        // }

    }

    void OnBecameInvisible()
    {
        // Destroy the GameObject
        Destroy(gameObject);
    }
}
