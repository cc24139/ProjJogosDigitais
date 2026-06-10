using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Referências")]
    public Image background;
    public Image borderFrame;
    public TextMeshProUGUI label;

    [Header("Cores — Normal")]
    public Color bgNormal     = new Color(0.086f, 0.071f, 0.039f); // #16120A
    public Color borderNormal = new Color(0.180f, 0.145f, 0.063f); // #2E2510
    public Color textNormal   = new Color(0.541f, 0.478f, 0.290f); // #8A7A4A

    [Header("Cores — Hover")]
    public Color bgHover     = new Color(0.110f, 0.086f, 0.039f);  // #1C160A
    public Color borderHover = new Color(0.361f, 0.290f, 0.118f);  // #5C4A1E
    public Color textHover   = new Color(0.784f, 0.722f, 0.478f);  // #C8B87A

    public void OnPointerEnter(PointerEventData e)
    {
        if (background)  background.color  = bgHover;
        if (borderFrame) borderFrame.color = borderHover;
        if (label)       label.color       = textHover;
    }

    public void OnPointerExit(PointerEventData e)
    {
        if (background)  background.color  = bgNormal;
        if (borderFrame) borderFrame.color = borderNormal;
        if (label)       label.color       = textNormal;
    }
}