using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Player: MonoBehaviour, IPlayer
{
    public HitBox hitBox;

    protected int health = 100;

    public void Attack()
    {
        Debug.Log("Player Attacking!");
    }

    public void Die()
    {
        Debug.Log("Player Died!");
    }

    public void Move()
    {
        Debug.Log("Player Moving!");
    }

    public void Super()
    {
        Debug.Log("Player Using Super!");
    }

    public void TakeDamge()
    {
        Debug.Log("Player Taking Damage!");
    }

    public void Start()
    {

    }

    public void Update()
    {

    }

}