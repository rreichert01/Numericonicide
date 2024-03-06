using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab;

    public Rigidbody2D rb; 
    public float speed = 20f;
    public GameObject player;
    public UIManager uiManager;
    public AmmoBar AmmoBarScript;
    public float reloadTime = 1f; // Length of reload time
    public int magazineCapacity = 8; // Number of rounds in the magazine
    private int currentAmmo; // Current ammo count in the magazine
    private bool isReloading; // Flag to indicate if the gun is currently reloading
    private bool isUp = false;
    public Transform parentObject;


    void Start()
    {
        currentAmmo = magazineCapacity; // Initialize current ammo count to full magazine
        //uiManager.UpdateBulletCountUI(currentAmmo);
        AmmoBarScript.updateAmmo(currentAmmo, magazineCapacity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!startCutscene.isCutsceneOn) {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                rotateGun();
            }
            if (Input.GetKeyDown(KeyCode.Space) && currentAmmo > 0 && !isReloading && IsChild())
            {
                Shoot();
            }

            // Check for input to reload if magazine is empty and not already reloading
            if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentAmmo != magazineCapacity)
            {
                AmmoBarScript.reloadAnimation(magazineCapacity, reloadTime);
                StartCoroutine(Reload());
            }
        }

    }

    void rotateGun()
    {
        if (isUp)
        {
            transform.rotation = Quaternion.LookRotation(parentObject.forward, Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        isUp = !isUp;
    }

    void Shoot() 
    {
        currentAmmo--;
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * speed * Math.Sign(transform.lossyScale.x);
        //uiManager.UpdateBulletCountUI(currentAmmo);
        AmmoBarScript.updateAmmo(currentAmmo, magazineCapacity);
    }

    IEnumerator Reload()
    {
        // Set reloading flag to true
        isReloading = true;

        // Simulate reloading time
        yield return new WaitForSeconds(reloadTime);

        // Refill magazine
        currentAmmo = magazineCapacity;

        // Set reloading flag to false
        isReloading = false;
        //uiManager.UpdateBulletCountUI(currentAmmo);
        AmmoBarScript.updateAmmo(currentAmmo, magazineCapacity);
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
