using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyweapon : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject enemyBulletPrefab;

    public Rigidbody2D rb; 
    public float speed = 20f;
    //public GameObject player;

    private float fireTimer = 0f; 
    public float fireRate = 1f; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        fireTimer += Time.deltaTime; 
        if (fireTimer >= fireRate){
            FireBullet(); 
            fireTimer = 0f; 
        }
        
    }

    void FireBullet(){
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation); 
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>(); 
        bulletRB.velocity = -firePoint.right * speed; 
    }

}
