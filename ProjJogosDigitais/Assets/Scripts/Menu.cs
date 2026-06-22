using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Painéis do Menu")]
    public GameObject mainMenuPanel;
    public GameObject charSelectPanel;

    public static int player1SelectedID;
    public static int player2SelectedID;

    void Start()
    {
        if (MatchData.menuDestination == "CharacterPicker")
        {
            if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
            if (charSelectPanel != null) charSelectPanel.SetActive(true);
        }
        else
        {
            if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
            if (charSelectPanel != null) charSelectPanel.SetActive(false);
        }

        MatchData.menuDestination = "";
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        charSelectPanel.SetActive(true);
    }

    public void IniciarCombate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}