using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class CharacterCombat : MonoBehaviour
{
    [Header("Attacks")]
    [SerializeField] private int attackCount ;

    private CharacterAnimator characterAnimator;
    private  CharacterHitBoxs characterHitBoxs;

    private void Awake()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
        characterHitBoxs = GetComponent<CharacterHitBoxs>();
    }


    public void Attack(int attackIndex)
    {
        if (attackIndex < 0 || attackIndex >= attackCount)
        {
            return;
        }
        characterHitBoxs.Attack();
        //characterAnimator.PlayAttack(attackIndex); animação já chama essa função
    }

    public int AttackCount
    {
        get { return attackCount; }
    }
}