using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [Header("Configurações do Projétil")]
    public GameObject arrowPrefab; 
    public Transform firePoint;    

    [Header("Tempo de Disparo")]
    public float startTimeDelay = 1f; 
    public float fireInterval = 2.5f; 

    void Start()
    {
        InvokeRepeating("Shoot", startTimeDelay, fireInterval);
    }

    void Shoot()
    {
        if (arrowPrefab != null)
        {
            Instantiate(arrowPrefab, firePoint.position, transform.rotation);
        }
    }
}