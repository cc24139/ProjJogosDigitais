using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
public class HitBoxHurt : HitBox
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HitBoxHurt triggered with: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
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