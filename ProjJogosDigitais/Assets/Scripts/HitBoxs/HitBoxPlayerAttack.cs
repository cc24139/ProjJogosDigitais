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
        Debug.Log("HitBoxPlayerAttack triggered with: " + collision.gameObject.name);
        if (collision.CompareTag(tag))
        {
            IPlayer player = collision.GetComponentInParent<IPlayer>();
            if (player != null){
                player.TakeDamge();
            }
            Debug.Log("Hit Enemy!");
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}