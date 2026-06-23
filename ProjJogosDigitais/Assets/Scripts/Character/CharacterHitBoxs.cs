using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;

/*
    Classe responsável por tratar de colisões e aplicar efeitos
*/

public enum PlayerSide
{
    P1,
    P2,
}

public class CharacterHitBoxs : MonoBehaviour
{
    [Header("HitBox")]
    // [SerializeField] private BoxCollider2D hitBox;
    [SerializeField]
    public PlayerSide playerSide;
    private HitBoxHurt hitBoxHurt;
    private HitBoxPlayerAttack hitBoxPlayerAttack;
    private HitBoxScenary hitBoxScenary;

    private void Awake()
    {
        hitBoxHurt = GetComponentInChildren<HitBoxHurt>();
        hitBoxPlayerAttack = GetComponentInChildren<HitBoxPlayerAttack>();
        hitBoxScenary = GetComponentInChildren<HitBoxScenary>();
        Normal();
    }

    public void SetupSide(PlayerSide side)
    {
        playerSide = side;
        ConfigureSide();
    }

    private void ConfigureSide()
    {
        Debug.Log("Player Side: " + playerSide);

        string selfLayer = (playerSide == PlayerSide.P1) ? "P1" : "P2";
        string playerHurtLayer = (playerSide == PlayerSide.P1) ? "P2Attack" : "P1Attack";
        string attackBoxLayer = (playerSide == PlayerSide.P1) ? "P1Attack" : "P2Attack";
        string attackBoxIncludeLayer = (playerSide == PlayerSide.P1) ? "P2" : "P1";

        int selfLayerIndex = LayerMask.NameToLayer(selfLayer);
        int selfAttackLayerIndex = LayerMask.NameToLayer(attackBoxLayer);

        int hurtMask = LayerMask.GetMask(playerHurtLayer);
        int attackMask = LayerMask.GetMask(attackBoxIncludeLayer);

        gameObject.layer = selfLayerIndex;
        hitBoxHurt.gameObject.layer = selfLayerIndex;
        hitBoxScenary.gameObject.layer = selfLayerIndex;
        hitBoxPlayerAttack.gameObject.layer = selfAttackLayerIndex;

        var hurtCollider = hitBoxHurt.hitBoxCollider;
        hurtCollider.includeLayers = hurtMask;
        hurtCollider.contactCaptureLayers = hurtMask;
        hurtCollider.callbackLayers = hurtMask;

        var attackCollider = hitBoxPlayerAttack.hitBoxCollider;
        attackCollider.includeLayers = attackMask;
        attackCollider.contactCaptureLayers = attackMask;
        attackCollider.callbackLayers = attackMask;
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
