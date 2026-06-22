using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreenManager : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    [Header("Nomes dos Personagens")]
    public TextMeshProUGUI p1CharacterNameText;
    public TextMeshProUGUI p2CharacterNameText;

    [Header("Componentes do Jogador 1")]
    public Image p1DamageBar;
    public TextMeshProUGUI p1DamageText;
    public Image p1HealBar;
    public TextMeshProUGUI p1HealText;
    public Image p1ManaBar;
    public TextMeshProUGUI p1ManaText;
    public Image p1SpecialsBar;
    public TextMeshProUGUI p1SpecialsText;

    [Header("Componentes do Jogador 2")]
    public Image p2DamageBar;
    public TextMeshProUGUI p2DamageText;
    public Image p2HealBar;
    public TextMeshProUGUI p2HealText;
    public Image p2ManaBar;
    public TextMeshProUGUI p2ManaText;
    public Image p2SpecialsBar;
    public TextMeshProUGUI p2SpecialsText;

    void Start()
    {
        if (winnerText != null) winnerText.text = MatchData.winnerName;
        if (p1CharacterNameText != null) p1CharacterNameText.text = MatchData.p1CharacterName;
        if (p2CharacterNameText != null) p2CharacterNameText.text = MatchData.p2CharacterName;

        ConfigurarBarrasComparativas();
        ConfigurarTextosNumericos();

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    void ConfigurarBarrasComparativas()
    {
        CalcularParDeBarras(MatchData.p1Damage, MatchData.p2Damage, p1DamageBar, p2DamageBar);
        CalcularParDeBarras(MatchData.p1Heal, MatchData.p2Heal, p1HealBar, p2HealBar);
        CalcularParDeBarras(MatchData.p1Mana, MatchData.p2Mana, p1ManaBar, p2ManaBar);
        CalcularParDeBarras(MatchData.p1Specials, MatchData.p2Specials, p1SpecialsBar, p2SpecialsBar);
    }

    void ConfigurarTextosNumericos()
    {
        if (p1DamageText != null) p1DamageText.text = MatchData.p1Damage.ToString();
        if (p2DamageText != null) p2DamageText.text = MatchData.p2Damage.ToString();

        if (p1HealText != null) p1HealText.text = MatchData.p1Heal.ToString();
        if (p2HealText != null) p2HealText.text = MatchData.p2Heal.ToString();

        if (p1ManaText != null) p1ManaText.text = MatchData.p1Mana.ToString();
        if (p2ManaText != null) p2ManaText.text = MatchData.p2Mana.ToString();

        if (p1SpecialsText != null) p1SpecialsText.text = MatchData.p1Specials.ToString();
        if (p2SpecialsText != null) p2SpecialsText.text = MatchData.p2Specials.ToString();
    }

    void CalcularParDeBarras(int valorP1, int valorP2, Image barraP1, Image barraP2)
    {
        if (barraP1 == null || barraP2 == null) return;

        if (valorP1 == 0 && valorP2 == 0)
        {
            barraP1.fillAmount = 0f;
            barraP2.fillAmount = 0f;
            return;
        }

        if (valorP1 >= valorP2)
        {
            barraP1.fillAmount = 1f;
            barraP2.fillAmount = (float)valorP2 / valorP1;
        }
        else
        {
            barraP2.fillAmount = 1f;
            barraP1.fillAmount = (float)valorP1 / valorP2;
        }
    }

    public void Revanche()
    {
        MatchData.menuDestination = "CharacterPicker";
        SceneManager.LoadScene("MenuScene");
    }

    public void VoltarMenu()
    {
        MatchData.menuDestination = "MainMenu";
        SceneManager.LoadScene("MenuScene");
    }
}