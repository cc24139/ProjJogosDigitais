using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [Header("Configuração da Grade")]
    public Transform[] characterSlots;  
    public int columns = 5; 

    [Header("Seletores (Molduras)")]
    public RectTransform p1Selector;
    public RectTransform p2Selector;

    [Header("Imagens de Preview (Opcional)")]
    public Image p1Preview;
    public Image p2Preview;

    private int p1Index = 0;
    private int p2Index = 4; 

    private bool p1Ready = false;
    private bool p2Ready = false;

    void Start()
    {
        AtualizarPosicaoSeletores();
    }

    void Update()
    {

        if (p1Ready && p2Ready)
        {
            
            Menu.player1SelectedID = p1Index;
            Menu.player2SelectedID = p2Index;
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        ControlesPlayer1();
        ControlesPlayer2();
    }

    void ControlesPlayer1()
    {
        if (p1Ready) return;


        if (Input.GetKeyDown(KeyCode.D) && (p1Index + 1) % columns != 0 && p1Index + 1 < characterSlots.Length)
            p1Index++;
        if (Input.GetKeyDown(KeyCode.A) && p1Index % columns != 0)
            p1Index--;


        if (Input.GetKeyDown(KeyCode.S) && p1Index + columns < characterSlots.Length)
            p1Index += columns;
        if (Input.GetKeyDown(KeyCode.W) && p1Index - columns >= 0)
            p1Index -= columns;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            p1Ready = true;
            Debug.Log("P1 Pronto!");
        }

        AtualizarPosicaoSeletores();
    }

    void ControlesPlayer2()
    {
        if (p2Ready) return;


        if (Input.GetKeyDown(KeyCode.RightArrow) && (p2Index + 1) % columns != 0 && p2Index + 1 < characterSlots.Length)
            p2Index++;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && p2Index % columns != 0)
            p2Index--;


        if (Input.GetKeyDown(KeyCode.DownArrow) && p2Index + columns < characterSlots.Length)
            p2Index += columns;
        if (Input.GetKeyDown(KeyCode.UpArrow) && p2Index - columns >= 0)
            p2Index -= columns;


        if (Input.GetKeyDown(KeyCode.Return))
        {
            p2Ready = true;
            Debug.Log("P2 Pronto!");
        }

        AtualizarPosicaoSeletores();
    }

    void AtualizarPosicaoSeletores()
    {
        
        if (!p1Ready) p1Selector.position = characterSlots[p1Index].position;
        if (!p2Ready) p2Selector.position = characterSlots[p2Index].position;

        
        if (p1Preview && characterSlots[p1Index].GetComponent<Image>())
            p1Preview.sprite = characterSlots[p1Index].GetComponent<Image>().sprite;
            
        if (p2Preview && characterSlots[p2Index].GetComponent<Image>())
            p2Preview.sprite = characterSlots[p2Index].GetComponent<Image>().sprite;
    }
}