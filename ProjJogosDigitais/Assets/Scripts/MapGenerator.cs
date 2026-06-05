using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Formatos de Mapas (Layout Prefabs)")]
    public GameObject[] mapLayouts; 

    [Header("Estilos de Plataforma")]
    public Sprite[] themeSprites; 

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
        GameObject spawnedLayout = Instantiate(mapLayouts[randomLayoutIndex], Vector3.zero, Quaternion.identity);

        if (themeSprites.Length > 0)
        {
            int randomSpriteIndex = Random.Range(0, themeSprites.Length);
            Sprite chosenTheme = themeSprites[randomSpriteIndex];

            SpriteRenderer[] platformRenderers = spawnedLayout.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer renderer in platformRenderers)
            {
                if (renderer.gameObject.name.Contains("Platform"))
                {
                    renderer.sprite = chosenTheme;
                }
            }
        }
        else
        {
            Debug.LogWarning("Nenhum sprite de tema foi colocado na lista do Map Generator!");
        }
    }
}