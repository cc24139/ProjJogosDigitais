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
        
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        return;
    }
}