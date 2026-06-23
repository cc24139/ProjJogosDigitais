using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Image healthBarFill;
    public Image manaBarFill;
    
    private CharacterStatus targetStatus;

    public void Setup(CharacterStatus status)
    {
        targetStatus = status;
        UpdateVisuals(); 
    }

    private void Update()
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (targetStatus == null) return;

        if (healthBarFill != null && targetStatus.MaxHealth > 0)
        {
            healthBarFill.fillAmount = (float)targetStatus.CurrentHealth / targetStatus.MaxHealth;
        }

        if (manaBarFill != null && targetStatus.MaxMana > 0)
        {
            manaBarFill.fillAmount = (float)targetStatus.CurrentMana / targetStatus.MaxMana;
        }
    }
}