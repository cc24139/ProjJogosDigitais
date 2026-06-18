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
        if (collision.CompareTag(tag) && isEnabled)
        {
            Debug.Log("Hit Player!");
            var player = GetComponentInParent<IDamage>();
            if (player != null)
            {
                player.TakeDamage(10); // Exemplo de dano
                Disable();
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}