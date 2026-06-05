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
            Debug.Log($"A armadilha acertou o {other.name}!");
            
            // Tirar a vida do jogador atingido

            Destroy(gameObject); 
        }
        
        if (other.gameObject.name.Contains("Platform") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}