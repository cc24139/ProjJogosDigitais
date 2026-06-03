using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [Header("Character Prefabs")]
    public GameObject[] characterPrefabs; 

    [Header("Spawn Points")]
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    void Start()
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        int p1ID = Menu.player1SelectedID;
        int p2ID = Menu.player2SelectedID;
        

        GameObject p1Prefab = characterPrefabs[p1ID];
        GameObject p1 = Instantiate(p1Prefab, player1SpawnPoint.position, player1SpawnPoint.rotation);
        
        p1.name = "Player 1"; 

        GameObject p2Prefab = characterPrefabs[p2ID];
        GameObject p2 = Instantiate(p2Prefab, player2SpawnPoint.position, player2SpawnPoint.rotation);
        
        p2.name = "Player 2";
        
        p2.transform.localScale = new Vector3(-p2.transform.localScale.x, p2.transform.localScale.y, p2.transform.localScale.z);
    }
}