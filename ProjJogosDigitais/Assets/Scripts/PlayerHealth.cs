using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public float maxHealth = 100f; 
    private float currentHealth;

    private Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        WalkingCharacter pc = GetComponent<WalkingCharacter>();
        if (pc != null)
        {
            if (pc.playerID == 1)
            {
                healthBar = GameObject.Find("HealthBar_P1")?.GetComponent<Image>();
            }
            else
            {
                healthBar = GameObject.Find("HealthBar_P2")?.GetComponent<Image>();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (healthBar == null)
        {
            int id = GetComponent<WalkingCharacter>().playerID;
            healthBar = GameObject.Find($"HealthBar_P{id}")?.GetComponent<Image>();
        }

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}