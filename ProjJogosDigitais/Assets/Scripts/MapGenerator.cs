using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Map Layouts")]
    public GameObject[] mapLayouts; 

    void Awake()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        if (mapLayouts.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, mapLayouts.Length);

        Instantiate(mapLayouts[randomIndex], Vector3.zero, Quaternion.identity);
    }
}