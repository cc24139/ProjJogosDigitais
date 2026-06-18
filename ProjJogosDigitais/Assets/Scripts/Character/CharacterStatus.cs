
using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;

public class CharacterStatus: MonoBehaviour, IDamage
{
    [Header("Status")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Lógica de morte do personagem
        Debug.Log("Personagem morreu!");
    }
}