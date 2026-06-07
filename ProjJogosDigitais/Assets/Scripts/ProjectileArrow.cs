using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 4f; 

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

        if (other.CompareTag("Player"))
        {
            Debug.Log($"HitBoxHurt triggered with: {other.name}");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                playerHealth = other.GetComponentInParent<PlayerHealth>();
            }

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(20); 
                Destroy(gameObject); 
                return; 
            }
        }
        
        if (other.gameObject.name.Contains("Platform") || other.CompareTag("Ground"))
        {
            Collider2D playerPerto = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Default")); 
            
            if (other.gameObject.CompareTag("Player") == false)
            {
                Destroy(gameObject);
            }
        }
    }
}