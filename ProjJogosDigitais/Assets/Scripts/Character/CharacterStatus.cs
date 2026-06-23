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

    [Header("Regeneração de Vida")]
    [SerializeField] private int healthRegenAmount = 2;
    [SerializeField] private float healthRegenInterval = 3f;

    private int currentHealth;
    private int currentMana;
    private CharacterHitBoxs hitBoxs;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public int CurrentMana => currentMana;
    public int MaxMana => maxMana;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana / 2;
        hitBoxs = GetComponent<CharacterHitBoxs>();
    }

    private void Start()
{
    StartCoroutine(RegenerateManaRoutine());
    StartCoroutine(RegenerateHealthRoutine());
}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (hitBoxs != null)
        {
            if (hitBoxs.playerSide == PlayerSide.P1)
                MatchData.p2Damage += damage;
            else
                MatchData.p1Damage += damage;
        }

        if (currentHealth <= 0)
            Die();
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0) currentMana = 0;

        if (hitBoxs != null)
        {
            if (hitBoxs.playerSide == PlayerSide.P1)
                MatchData.p1Mana += amount;
            else
                MatchData.p2Mana += amount;
        }
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

    private IEnumerator RegenerateHealthRoutine()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(healthRegenInterval);
            int actual = Mathf.Min(healthRegenAmount, maxHealth - currentHealth);
            currentHealth += actual;

            if (hitBoxs != null)
            {
                if (hitBoxs.playerSide == PlayerSide.P1)
                    MatchData.p1Heal += actual;
                else
                    MatchData.p2Heal += actual;
            }
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