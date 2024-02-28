using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float maxHeight = 5f; // Maximum height of the health bar
    public float heightMultiplier = 1000f; // Multiplier to adjust the height
    public Player playerScript;
    private Vector3 originalScale;
    private Vector2 originalPosition;
    private RectTransform rectTransform;

    void Start()
    {
        originalScale = transform.localScale;
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void updateHealth(float health, float maxHealth)
    {
        float healthPercentage = health / maxHealth;
        Vector3 newScale = new Vector3(transform.localScale.x, healthPercentage * originalScale.y, transform.localScale.z);
        transform.localScale = newScale;
        float yOffset = (originalScale.y - healthPercentage * originalScale.y) / 2f;

        Vector3 newPosition = new Vector2(originalPosition.x, originalPosition.y - yOffset);
        UnityEngine.Debug.Log((Vector3.up * yOffset));
        rectTransform.anchoredPosition = newPosition;
    }
}