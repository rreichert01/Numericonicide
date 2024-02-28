using UnityEngine;
using System;
using System.Collections;


public class AmmoBar : MonoBehaviour
{
    public float maxHeight = 5f; // Maximum height of the health bar
    public float heightMultiplier = 1000f; // Multiplier to adjust the height
    public Weapon gunScript;
    private Vector3 originalScale;
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private bool isFlashing = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float _ammo = 1;


    void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = transform.localScale;
        originalPosition = rectTransform.anchoredPosition;
        GameObject obj = GameObject.Find("AmmoBarBack");
        spriteRenderer = obj.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Start() 
    {
       /*  originalScale = transform.localScale;
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition; */
    }

    IEnumerator ChangeColorCoroutine(Color newColor, float duration)
    {   
        while (_ammo == 0) {
        // Change the color go the new color
        spriteRenderer.color = newColor;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration / 2);

        // Change the color back to the original color
        spriteRenderer.color = originalColor;

        yield return new WaitForSeconds(duration / 2);
        }
    }
    public void reloadAnimation(int maxAmmo, float reloadTime)
    {
        StartCoroutine(reloadAnim( reloadTime / (float) maxAmmo, maxAmmo));
    }

    IEnumerator reloadAnim(float waitTime, int maxAmmo)
    {
        int currentAmmo = 0;
        spriteRenderer.color = originalColor;
        while (currentAmmo < maxAmmo)
        {
            currentAmmo++;
            updateAmmo(currentAmmo, maxAmmo);
            yield return new WaitForSeconds(waitTime);
        }
        
    }



    public void updateAmmo(float ammo, float maxAmmo) {
        float healthPercentage = ammo / maxAmmo;
        Vector3 newScale = new Vector3(transform.localScale.x, healthPercentage * originalScale.y, transform.localScale.z);
        transform.localScale = newScale;
        float yOffset = (originalScale.y - healthPercentage * originalScale.y) / 2f;
        
        Vector3 newPosition = new Vector2(originalPosition.x, originalPosition.y - yOffset);
        rectTransform.anchoredPosition = newPosition;
        _ammo = ammo;
        if (ammo == 0) {
            StartCoroutine(ChangeColorCoroutine(Color.red, 0.6f));
        }
    }
}