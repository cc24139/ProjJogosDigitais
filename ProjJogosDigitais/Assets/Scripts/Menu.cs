using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Cena1"); 
    }

    public void OpenSettings()
    {
        // show settings panel, etc.
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}