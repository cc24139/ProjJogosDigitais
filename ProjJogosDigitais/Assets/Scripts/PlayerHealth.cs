using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Image healthBarFill; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateVisuals();
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        UpdateVisuals();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateVisuals()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}