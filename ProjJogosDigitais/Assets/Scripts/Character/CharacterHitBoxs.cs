using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
/*
    Classe responsável por tratar de colisões e aplicar efeitos
*/

public class CharacterHitBoxs : MonoBehaviour
{
    [Header("HitBox")]
    [SerializeField] private BoxCollider2D hitBox;
    private HitBoxHurt hitBoxHurt;
    private HitBoxPlayerAttack hitBoxPlayerAttack;
    private HitBoxScenary hitBoxScenary;

    private void Awake()
    {
        hitBoxHurt = hitBox.GetComponentInChildren<HitBoxHurt>();
        hitBoxPlayerAttack = hitBox.GetComponentInChildren<HitBoxPlayerAttack>();
        hitBoxScenary = hitBox.GetComponentInChildren<HitBoxScenary>();
        DisableAllHitBox();
    }

    private void DisableAllHitBox()
    {
        hitBoxHurt.isEnabled = false;
        hitBoxPlayerAttack.isEnabled = false;
        hitBoxScenary.isEnabled = false;
    }

    public void Attack()
    {
        hitBoxPlayerAttack.isEnabled = true;
        hitBoxHurt.isEnabled = false;
        hitBoxScenary.isEnabled = false;
    }

    public void Invulnerable()
    {
        hitBoxHurt.isEnabled = false;
        hitBoxPlayerAttack.isEnabled = false;
        hitBoxScenary.isEnabled = false;
    }
    public void Normal()
    {
        hitBoxHurt.isEnabled = true;
        hitBoxPlayerAttack.isEnabled = false;
        hitBoxScenary.isEnabled = true;
    }


    

}
