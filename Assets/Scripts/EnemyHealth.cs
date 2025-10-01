using UnityEngine;      // For MonoBehaviour
using UnityEngine.UI;   // For Slider

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Slider healthSlider;  // Drag UI Slider here

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.minValue = 0;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (currentHealth == 0)
            Die();
    }

    private void Die()
    {
        // Award points safely
        if (GameManager.Instance != null)
            GameManager.Instance.IncrementScore(1); // ✅ now exists

        Destroy(gameObject);
    }

}