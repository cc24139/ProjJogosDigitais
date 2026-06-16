using UnityEngine;
using UnityEngine.UI;

public class GameSpawner : MonoBehaviour
{
    [Header("Character Prefabs")]
    public GameObject[] characterPrefabs;

    [Header("Referências da UI")]
    public Image healthBarFillP1; 
    public Image healthBarFillP2; 

    void Start()
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        GameObject p1Point = GameObject.Find("P1_SpawnPoint");
        GameObject p2Point = GameObject.Find("P2_SpawnPoint");


        int p1ID = Menu.player1SelectedID;
        int p2ID = Menu.player2SelectedID;

        GameObject p1 = Instantiate(characterPrefabs[p1ID], p1Point.transform.position, p1Point.transform.rotation);
        p1.name = "Player 1";
        p1.GetComponent<WalkingCharacter>().playerID = 1;
        p1.GetComponent<PlayerHealth>().healthBarFill = healthBarFillP1;

        GameObject p2 = Instantiate(characterPrefabs[p2ID], p2Point.transform.position, p2Point.transform.rotation);
        p2.name = "Player 2";
        p2.transform.localScale = new Vector3(-p2.transform.localScale.x, p2.transform.localScale.y, p2.transform.localScale.z);
        p2.GetComponent<WalkingCharacter>().playerID = 2;
        p2.GetComponent<PlayerHealth>().healthBarFill = healthBarFillP2;
    }
}