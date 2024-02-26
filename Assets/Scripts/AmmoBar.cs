using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    public float maxHeight = 5f; // Maximum height of the health bar
    public float heightMultiplier = 1000f; // Multiplier to adjust the height
    public Weapon gunScript;
    private Vector3 originalScale;
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = transform.localScale;
        originalPosition = rectTransform.anchoredPosition;
    }

    void Start() 
    {
       /*  originalScale = transform.localScale;
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition; */
    }

    public void updateAmmo(float ammo, float maxAmmo) {
        float healthPercentage = ammo / maxAmmo;
        Vector3 newScale = new Vector3(transform.localScale.x, healthPercentage * originalScale.y, transform.localScale.z);
        transform.localScale = newScale;
        float yOffset = (originalScale.y - healthPercentage * originalScale.y) / 2f;
        
        Vector3 newPosition = new Vector2(originalPosition.x, originalPosition.y - yOffset);
        rectTransform.anchoredPosition = newPosition;
    }
}