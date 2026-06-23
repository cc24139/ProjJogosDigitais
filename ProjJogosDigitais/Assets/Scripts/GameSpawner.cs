using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [Header("Character Prefabs")]
    public GameObject[] characterPrefabs;

    [Header("Referências do HUD")]
    public PlayerHUD hudP1;
    public PlayerHUD hudP2;

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

        if (p1Point != null && characterPrefabs[p1ID] != null)
        {
            GameObject p1 = Instantiate(characterPrefabs[p1ID], p1Point.transform.position, p1Point.transform.rotation);
            p1.name = "Player 1";

            CharacterHitBoxs hitBoxsP1 = p1.GetComponent<CharacterHitBoxs>();
            
            if (hitBoxsP1 != null)
                hitBoxsP1.SetupSide(PlayerSide.P1);
            p1.SendMessage("Configure", SendMessageOptions.DontRequireReceiver);

            if (p1.GetComponent<WalkingCharacter>() != null) p1.GetComponent<WalkingCharacter>().playerID = 1;
            
            CharacterStatus statusP1 = p1.GetComponent<CharacterStatus>();
            if (statusP1 != null && hudP1 != null) hudP1.Setup(statusP1);
            
            MatchData.p1CharacterName = characterPrefabs[p1ID].name;
        }

        if (p2Point != null && characterPrefabs[p2ID] != null)
        {

            GameObject p2 = Instantiate(characterPrefabs[p2ID], p2Point.transform.position, p2Point.transform.rotation);
            p2.name = "Player 2";

            CharacterHitBoxs hitBoxsP2 = p2.GetComponent<CharacterHitBoxs>();
            if (hitBoxsP2 != null)
                hitBoxsP2.SetupSide(PlayerSide.P2);

            p2.SendMessage("Configure", SendMessageOptions.DontRequireReceiver);

            if (p2.GetComponent<WalkingCharacter>() != null) p2.GetComponent<WalkingCharacter>().playerID = 2;
            
            CharacterStatus statusP2 = p2.GetComponent<CharacterStatus>();
            if (statusP2 != null && hudP2 != null) hudP2.Setup(statusP2);


            MatchData.p2CharacterName = characterPrefabs[p2ID].name;
        }
    }
}