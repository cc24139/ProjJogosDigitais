using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage damageable = collision.GetComponent<IDamage>();
        if (damageable == null)
        {
            damageable = collision.GetComponentInParent<IDamage>();
        }

        if (damageable != null)
        {
            damageable.TakeDamage(9999);
        }
    }
}