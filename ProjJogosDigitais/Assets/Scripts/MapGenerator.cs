using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Formatos de Mapas (Layout Prefabs)")]
    public GameObject[] mapLayouts; 

    void Awake()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        if (mapLayouts.Length == 0)
        {
            Debug.LogWarning("Nenhum layout atribuído ao Map Generator!");
            return;
        }

        int randomLayoutIndex = Random.Range(0, mapLayouts.Length);
        
        Instantiate(mapLayouts[randomLayoutIndex], Vector3.zero, Quaternion.identity);
    }
}