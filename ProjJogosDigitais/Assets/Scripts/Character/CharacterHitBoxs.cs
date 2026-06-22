using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;

/*
    Classe responsável por tratar de colisões e aplicar efeitos
*/


public enum PlayerSide
{
    P1,
    P2
}

public class CharacterHitBoxs : MonoBehaviour
{
    [Header("HitBox")]
    // [SerializeField] private BoxCollider2D hitBox;
    [SerializeField] public PlayerSide playerSide;
    private HitBoxHurt hitBoxHurt;
    private HitBoxPlayerAttack hitBoxPlayerAttack;
    private HitBoxScenary hitBoxScenary;

    private void Awake()
    {
        hitBoxHurt = GetComponentInChildren<HitBoxHurt>();
        hitBoxPlayerAttack = GetComponentInChildren<HitBoxPlayerAttack>();
        hitBoxScenary = GetComponentInChildren<HitBoxScenary>();
        ConfigureSide();
        Normal();
    }

    private void ConfigureSide()
    {
        string selfLayer = playerSide == PlayerSide.P1 ? "P1" : "P2";
        string selfAttackLayer = playerSide == PlayerSide.P1 ? "P1Attack" : "P2Attack";
        string enemyLayer = playerSide == PlayerSide.P1 ? "P2" : "P1";

        int selfLayerIndex = LayerMask.NameToLayer(selfLayer);
        int selfAttackLayerIndex = LayerMask.NameToLayer(selfAttackLayer);
        int enemyLayerMask = LayerMask.GetMask(enemyLayer);

        gameObject.layer = selfLayerIndex;
        hitBoxHurt.gameObject.layer = selfLayerIndex;
        hitBoxScenary.gameObject.layer = selfLayerIndex;

        hitBoxPlayerAttack.gameObject.layer = selfAttackLayerIndex;

        hitBoxPlayerAttack.hitBoxCollider.includeLayers = enemyLayerMask;
    }
    public void Attack()
    {
        hitBoxHurt.Disable();
        hitBoxPlayerAttack.Enable();
        hitBoxScenary.Disable();
    }

    public void Invulnerable()
    {
        hitBoxHurt.Disable();
        hitBoxPlayerAttack.Disable();
        hitBoxScenary.Disable();
    }

    public void Normal()
    {
        hitBoxHurt.Enable();
        hitBoxPlayerAttack.Disable();
        hitBoxScenary.Enable();
    }
}
