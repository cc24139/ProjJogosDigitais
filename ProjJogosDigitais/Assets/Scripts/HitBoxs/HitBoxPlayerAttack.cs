using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;
/*
    Hitbox responsável por detectar colisões dos ataques do player com os inimigos
*/
public class HitBoxPlayerAttack : HitBox
{
    private const string tag = "Enemy";

    public override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(tag) && isEnabled)
        {
            Debug.Log("HitBoxPlayerAttack triggered with: " + collision.gameObject.name);
            var player = collision.GetComponentInParent<IDamage>();
            var playerAnimation = collision.GetComponentInParent<CharacterAnimator>();
            if (player != null && playerAnimation != null)
            {
                playerAnimation.PlayTakeHit();
                player.TakeDamage(10);
                Disable();
            }
            Debug.Log("Hit Enemy!");
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}