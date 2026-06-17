using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    [Header("Atributos de Mana")]
    public float maxMana = 100f;
    private float currentMana;
    
    [Tooltip("Quantidade de mana recuperada por segundo")]
    public float manaRegenRate = 5f; 

    [Header("Interface (UI)")]
    public Image manaBarFill; 

    void Start()
    {
        currentMana = maxMana/2;
        UpdateVisuals();
    }

    void Update()
    {
        if (currentMana < maxMana)
        {
            currentMana += manaRegenRate * Time.deltaTime;
            
            currentMana = Mathf.Clamp(currentMana, 0f, maxMana);
            
            UpdateVisuals();
        }
    }

    public bool UseMana(float cost)
    {
        if (currentMana >= cost)
        {
            currentMana -= cost;
            UpdateVisuals();
            return true; 
        }
        else
        {
            Debug.Log("Sem mana suficiente!");
            return false; 
        }
    }

    private void UpdateVisuals()
    {
        if (manaBarFill != null)
        {
            manaBarFill.fillAmount = currentMana / maxMana;
        }
    }
}