using ProjJogosDigitais.Assets.Scripts.Interfaces;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 4f; 
    public int damageAmount = 20;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable == null)
        {
            damageable = other.GetComponentInParent<IDamage>();
        }

        if (damageable != null)
        {
            Debug.Log($"Flecha acertou e causou dano em: {other.name}");
            damageable.TakeDamage(damageAmount); 
            Destroy(gameObject); 
            return; 
        }
        
        if (other.gameObject.name.Contains("Platform") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}