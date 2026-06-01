using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

public class HitBoxPlayyerAttack : HitBox
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HitBoxPlayerAttack triggered with: " + collision.gameObject.name);
        if (collision.CompareTag("Enemy"))
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