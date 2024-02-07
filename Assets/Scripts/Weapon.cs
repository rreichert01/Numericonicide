using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab; 

    public Rigidbody2D rb; 
    public float speed = 20f; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); 
        }
        
    }

    void Shoot() 
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed; 

    }
}
