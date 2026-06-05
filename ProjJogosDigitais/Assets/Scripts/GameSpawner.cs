using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [Header("Character Prefabs")]
    public GameObject[] characterPrefabs; 


    void Start()
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        GameObject p1Point = GameObject.Find("P1_SpawnPoint");
        GameObject p2Point = GameObject.Find("P2_SpawnPoint");

        if (p1Point == null || p2Point == null)
        {
            Debug.LogError("ERRO: Não encontrei os objetos 'P1_SpawnPoint' ou 'P2_SpawnPoint' no mapa gerado!");
            return;
        }

        int p1ID = Menu.player1SelectedID;
        int p2ID = Menu.player2SelectedID;

        GameObject p1Prefab = characterPrefabs[p1ID];
        GameObject p1 = Instantiate(p1Prefab, p1Point.transform.position, p1Point.transform.rotation);
        p1.name = "Player 1"; 

        GameObject p2Prefab = characterPrefabs[p2ID];
        GameObject p2 = Instantiate(p2Prefab, p2Point.transform.position, p2Point.transform.rotation);
        p2.name = "Player 2";
        
        p2.transform.localScale = new Vector3(-p2.transform.localScale.x, p2.transform.localScale.y, p2.transform.localScale.z);
    }
}