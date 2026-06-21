using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

/*
    HitBox reponsável por detectar colisões do player com objetos que causam dano
*/
public class HitBoxHurt : HitBox
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HitBoxHurt: OnTriggerEnter2D - " + collision.gameObject.name);
        if (!isEnabled)
            return;
        var controller = GetComponentInParent<CharacterController>();
        if (controller != null)
        {
            Debug.Log("Achou Controller!");
            controller.OnHit(10);
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}
