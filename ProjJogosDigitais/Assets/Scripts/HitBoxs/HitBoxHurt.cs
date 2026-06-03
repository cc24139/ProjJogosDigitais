using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
/*
    HitBox reponsável por detectar colisões do player com objetos que causam dano
*/
public class HitBoxHurt : HitBox
{
    private const string tag = "Enemy";
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HitBoxHurt triggered with: " + collision.gameObject.name);
        if (collision.CompareTag(tag))
        {
            Debug.Log("Hit Player!");
            IPlayer player = GetComponentInParent<IPlayer>();
            if (player != null)
            {
                player.TakeDamge();
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}