using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab;

    public Rigidbody2D rb; 
    public float speed = 20f;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsChild())
        {
            Shoot();
        }
        
    }

    void Shoot() 
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed; 

    }

    public bool IsChild()
    {
        // Check if the potentialChild's transform has a parent
        if (gameObject.transform.parent != null)
        {
            // Check if the parent of the potentialChild matches the potentialParent
            if (gameObject.transform.parent.gameObject == player)
            {
                // The potentialChild is a child of the potentialParent
                return true;
            }
        }

        // The potentialChild is not a child of the potentialParent
        return false;
    }
}
