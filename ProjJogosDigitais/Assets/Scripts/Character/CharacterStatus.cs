using System.Collections;
using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;

public class CharacterStatus : MonoBehaviour, IDamage
{
    [Header("Status")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxMana = 100;

    [Header("Regeneração de Mana")]
    [SerializeField] private int manaRegenAmount = 5;
    [SerializeField] private float manaRegenInterval = 1f;

    private int currentHealth;
    private int currentMana;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public int CurrentMana => currentMana;
    public int MaxMana => maxMana;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana / 2;
    }

    private void Start()
    {
        StartCoroutine(RegenerateManaRoutine());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0) currentMana = 0;
    }

    public void GainMana(int amount)
    {
        currentMana += amount;
        if (currentMana > maxMana) currentMana = maxMana;
    }

    public bool CanAffordMana(int amount)
    {
        return currentMana >= amount;
    }

    private IEnumerator RegenerateManaRoutine()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(manaRegenInterval);
            GainMana(manaRegenAmount);
        }
    }

    public void Die()
    {
        StopAllCoroutines();

        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.Die();
        }
        else
        {
            Debug.LogWarning("CharacterController não encontrado no personagem ao morrer!");
        }
    }
}