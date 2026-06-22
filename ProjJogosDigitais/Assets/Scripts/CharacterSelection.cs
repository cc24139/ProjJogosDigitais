using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    [Header("Configuração da Grade")]
    public Transform[] characterSlots;  
    public int columns = 5; 

    [Header("Animações dos Personagens")]
    public RuntimeAnimatorController[] characterAnimators; 

    [Header("Nomes dos Personagens")]
    public string[] characterNames; 

    [Header("Textos de Preview")]
    public TextMeshProUGUI p1NameText;
    public TextMeshProUGUI p2NameText;

    [Header("Textos de Indicador")]
    public TextMeshProUGUI p1PromptText;
    public TextMeshProUGUI p2PromptText;

    [Header("Seletores (Molduras)")]
    public RectTransform p1Selector;
    public RectTransform p2Selector;

    [Header("Imagens de Preview (Animadas)")]
    public Animator p1Preview; 
    public Animator p2Preview; 

    private int p1Index = 0;
    private int p2Index = 1; 

    private bool p1Ready = false;
    private bool p2Ready = false;

    void Start()
    {
        AtualizarPosicaoSeletores();
        if (p1PromptText != null) p1PromptText.text = "- Pressione ESPAÇO -";
        if (p2PromptText != null) p2PromptText.text = "- Pressione ENTER -";
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

        if (Input.GetKeyDown(KeyCode.D) && (p1Index + 1) % columns != 0 && p1Index + 1 < characterSlots.Length) p1Index++;
        if (Input.GetKeyDown(KeyCode.A) && p1Index % columns != 0) p1Index--;
        if (Input.GetKeyDown(KeyCode.S) && p1Index + columns < characterSlots.Length) p1Index += columns;
        if (Input.GetKeyDown(KeyCode.W) && p1Index - columns >= 0) p1Index -= columns;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            p1Ready = true;
            if (p1PromptText != null) p1PromptText.text = "- PRONTO! -";
            Debug.Log("P1 Pronto!");
        }

        AtualizarPosicaoSeletores();
    }

    void ControlesPlayer2()
    {
        if (p2Ready) return;

        if (Input.GetKeyDown(KeyCode.RightArrow) && (p2Index + 1) % columns != 0 && p2Index + 1 < characterSlots.Length) p2Index++;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && p2Index % columns != 0) p2Index--;
        if (Input.GetKeyDown(KeyCode.DownArrow) && p2Index + columns < characterSlots.Length) p2Index += columns;
        if (Input.GetKeyDown(KeyCode.UpArrow) && p2Index - columns >= 0) p2Index -= columns;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            p2Ready = true;
            if (p2PromptText != null) p2PromptText.text = "- PRONTO! -";
            Debug.Log("P2 Pronto!");
        }

        AtualizarPosicaoSeletores();
    }

    void AtualizarPosisser()
    {
        
    }

    void AtualizarPosicaoSeletores()
    {
        if (!p1Ready) p1Selector.position = characterSlots[p1Index].position;
        if (!p2Ready) p2Selector.position = characterSlots[p2Index].position;

        if (p1Preview != null && characterAnimators.Length > p1Index)
        {
            if (p1Preview.runtimeAnimatorController != characterAnimators[p1Index])
                p1Preview.runtimeAnimatorController = characterAnimators[p1Index];
        }
            
        if (p2Preview != null && characterAnimators.Length > p2Index)
        {
            if (p2Preview.runtimeAnimatorController != characterAnimators[p2Index])
                p2Preview.runtimeAnimatorController = characterAnimators[p2Index];
        }

        if (p1NameText != null && characterNames.Length > p1Index)
        {
            p1NameText.text = characterNames[p1Index];
        }

        if (p2NameText != null && characterNames.Length > p2Index)
        {
            p2NameText.text = characterNames[p2Index];
        }
    }
}