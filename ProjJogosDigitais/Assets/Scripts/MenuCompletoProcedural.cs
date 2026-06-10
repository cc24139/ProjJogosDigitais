using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCompletoProcedural : MonoBehaviour
{
    [Header("Configurações de Fontes")]
    public TMP_FontAsset fonteCinzelDecorativeBold; // Para o título "FALLEN ORDERS"
    public TMP_FontAsset fonteCinzelRegular;        // Para o subtítulo e botões

    [Header("Sprites Opcionais (Se tiver os Packs)")]
    public Sprite spriteRachaduraFundo;
    public Sprite spriteBordaBotao;

    void Start()
    {
        // 1. GARANTIR CANVAS CONFIGURADO (1920x1080)
        Canvas canvas = FindFirstObjectByType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            
            CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 0.5f;

            canvasObj.AddComponent<GraphicRaycaster>();
        }

        // 2. FUNDO (Cores do Guia)
        Transform canvasTr = canvas.transform;
        CriarFundo(canvasTr);

        // 3. BARRAS DECORATIVAS (Topo e Rodapé)
        CriarBarraDecorativa(canvasTr, "TopBar", true);
        CriarBarraDecorativa(canvasTr, "BottomBar", false);

        // 4. PAINEL CENTRALIZADO (PANEL)
        GameObject panelObj = new GameObject("Panel", typeof(RectTransform));
        panelObj.transform.SetParent(canvasTr, false);
        RectTransform panelRect = panelObj.GetComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(500, 700);
        panelRect.anchoredPosition = Vector2.zero;

        VerticalLayoutGroup layout = panelObj.AddComponent<VerticalLayoutGroup>();
        layout.spacing = 15;
        layout.childAlignment = TextAnchor.MiddleCenter;
        layout.childControlWidth = true;
        layout.childControlHeight = false;

        // 5. TÍTULOS (Com espaçamentos exatos do guia)
        CriarTextoTMPro(panelObj.transform, "TitleFallenOrders", "FALLEN\nORDERS", 52, ConvertHex("#C8B87A"), fonteCinzelDecorativeBold, 10, -10);
        CriarTextoTMPro(panelObj.transform, "TitleTorneio", "— O TORNEIO —", 16, ConvertHex("#5C4A1E"), fonteCinzelRegular, 20, 0);

        // Espaço e Linha Ornamental (Opção A: Losango integrado)
        CriarLinhaOrnamental(panelObj.transform);

        // Spacer sutil antes dos botões
        new GameObject("Spacer", typeof(RectTransform)).transform.SetParent(panelObj.transform, false);

        // 6. CRIAÇÃO DOS BOTÕES COM HOVER E DETALHES DE CANTOS
        CriarBotaoCompleto(panelObj.transform, "COMBATER", OnCombater);
        CriarBotaoCompleto(panelObj.transform, "SOBRE O PROJETO", OnSobre);
        CriarBotaoCompleto(panelObj.transform, "SAIR", OnSair);
    }

    #region Métodos de Construção Visual

    void CriarFundo(Transform pai)
    {
        // Cor sólida escura (#111008)
        GameObject bgCor = new GameObject("BgColor", typeof(RectTransform), typeof(Image));
        bgCor.transform.SetParent(pai, false);
        ConfigurarStretchTotal(bgCor.GetComponent<RectTransform>());
        bgCor.GetComponent<Image>().color = ConvertHex("#111008");

        // Textura de rachadura (Opcional)
        if (spriteRachaduraFundo != null)
        {
            GameObject crack = new GameObject("CrackTexture", typeof(RectTransform), typeof(Image));
            crack.transform.SetParent(bgCor.transform, false);
            ConfigurarStretchTotal(crack.GetComponent<RectTransform>());
            
            Image imgCrack = crack.GetComponent<Image>();
            imgCrack.sprite = spriteRachaduraFundo;
            imgCrack.type = Image.Type.Tiled;
            imgCrack.color = new Color(1f, 1f, 1f, 0.08f); // Alpha sutil entre 15-25 (0.08f fica suave)
        }
    }

    void CriarBarraDecorativa(Transform pai, string nome, bool noTopo)
    {
        GameObject barra = new GameObject(nome, typeof(RectTransform), typeof(Image));
        barra.transform.SetParent(pai, false);
        
        RectTransform rect = barra.GetComponent<RectTransform>();
        
        // Pega o componente Image para aplicar a cor corretamente
        Image img = barra.GetComponent<Image>();
        img.color = ConvertHex("#8A7030"); // Cor dourada das faixas

        if (noTopo)
        {
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(1, 1);
            rect.pivot = new Vector2(0.5f, 1);
        }
        else
        {
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 0);
            rect.pivot = new Vector2(0.5f, 0);
        }

        rect.sizeDelta = new Vector2(0, 4); // Altura de 4px do guia
        rect.anchoredPosition = Vector2.zero;
    }

    void CriarTextoTMPro(Transform pai, string nomeObjeto, string conteudo, float tamanho, Color cor, TMP_FontAsset fonte, float spacing, float lineSpacing)
    {
        GameObject txtObj = new GameObject(nomeObjeto, typeof(RectTransform), typeof(TextMeshProUGUI));
        txtObj.transform.SetParent(pai, false);

        TextMeshProUGUI tmp = txtObj.GetComponent<TextMeshProUGUI>();
        tmp.text = conteudo;
        tmp.fontSize = tamanho;
        tmp.color = cor;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.font = fonte;
        tmp.characterSpacing = spacing;
        tmp.lineSpacing = lineSpacing;
    }

    void CriarLinhaOrnamental(Transform pai)
    {
        // Container da linha para o VerticalLayoutGroup respeitar o espaço
        GameObject dividerContainer = new GameObject("OrnamentLine", typeof(RectTransform));
        dividerContainer.transform.SetParent(pai, false);
        dividerContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 20);

        // A linha fina esticada
        GameObject linha = new GameObject("Linha", typeof(RectTransform), typeof(Image));
        linha.transform.SetParent(dividerContainer.transform, false);
        RectTransform linhaRect = linha.GetComponent<RectTransform>();
        linhaRect.anchorMin = new Vector2(0, 0.5f);
        linhaRect.anchorMax = new Vector2(1, 0.5f);
        linhaRect.sizeDelta = new Vector2(0, 1); // 1px de altura
        linhaRect.anchoredPosition = Vector2.zero;
        linha.GetComponent<Image>().color = ConvertHex("#5C4A1E");

        // O Losango centralizado
        GameObject losango = new GameObject("Losango", typeof(RectTransform), typeof(Image));
        losango.transform.SetParent(dividerContainer.transform, false);
        RectTransform losangoRect = losango.GetComponent<RectTransform>();
        losangoRect.anchorMin = new Vector2(0.5f, 0.5f);
        losangoRect.anchorMax = new Vector2(0.5f, 0.5f);
        losangoRect.sizeDelta = new Vector2(8, 8); // Tamanho do losango
        losangoRect.anchoredPosition = Vector2.zero;
        losangoRect.localRotation = Quaternion.Euler(0, 0, 45); // Rotaciona 45º para virar losango
        losango.GetComponent<Image>().color = ConvertHex("#5C4A1E");
    }

    void CriarBotaoCompleto(Transform pai, string textoBotao, UnityEngine.Events.UnityAction acao)
    {
        // Raiz do Botão
        GameObject btnObj = new GameObject("Btn" + textoBotao.Replace(" ", ""), typeof(RectTransform), typeof(Button));
        btnObj.transform.SetParent(pai, false);
        RectTransform btnRect = btnObj.GetComponent<RectTransform>();
        btnRect.sizeDelta = new Vector2(280, 48); // Dimensões do Passo 8

        // BtnBackground (Fundo escuro #16120A)
        GameObject bgObj = new GameObject("BtnBackground", typeof(RectTransform), typeof(Image));
        bgObj.transform.SetParent(btnObj.transform, false);
        ConfigurarStretchTotal(bgObj.GetComponent<RectTransform>());
        Image imgBg = bgObj.GetComponent<Image>();
        imgBg.color = ConvertHex("#16120A");

        // BorderFrame (Borda 9-slice #2E2510)
        GameObject bordaObj = new GameObject("BorderFrame", typeof(RectTransform), typeof(Image));
        bordaObj.transform.SetParent(btnObj.transform, false);
        ConfigurarStretchTotal(bordaObj.GetComponent<RectTransform>());
        Image imgBorda = bordaObj.GetComponent<Image>();
        imgBorda.color = ConvertHex("#2E2510");
        if (spriteBordaBotao != null)
        {
            imgBorda.sprite = spriteBordaBotao;
            imgBorda.type = Image.Type.Sliced;
        }

        // Criar Cantos Decorativos (TL, TR, BL, BR) - Formando pequenos Ls de 10x10px
        CriarCantoDecorativo(btnObj.transform, "CornerTL", new Vector2(0, 1), new Vector2(4, -4));
        CriarCantoDecorativo(btnObj.transform, "CornerTR", new Vector2(1, 1), new Vector2(-4, -4));
        CriarCantoDecorativo(btnObj.transform, "CornerBL", new Vector2(0, 0), new Vector2(4, 4));
        CriarCantoDecorativo(btnObj.transform, "CornerBR", new Vector2(1, 0), new Vector2(-4, 4));

        // Label (TextMeshPro)
        GameObject labelObj = new GameObject("Label", typeof(RectTransform), typeof(TextMeshProUGUI));
        labelObj.transform.SetParent(btnObj.transform, false);
        ConfigurarStretchTotal(labelObj.GetComponent<RectTransform>());
        
        TextMeshProUGUI tmpLabel = labelObj.GetComponent<TextMeshProUGUI>();
        tmpLabel.text = textoBotao;
        tmpLabel.fontSize = 18;
        tmpLabel.color = ConvertHex("#8A7A4A"); // Cor normal do texto
        tmpLabel.alignment = TextAlignmentOptions.Center;
        tmpLabel.font = fonteCinzelRegular;
        tmpLabel.characterSpacing = 8;

        // Configurar Eventos do Componente Button
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(acao);

        // Adicionar o script de Hover dinamicamente e injetar as referências
        //MenuButtonHover hoverScript = btnObj.AddComponent<MenuButtonHover>();
        //hoverScript.background = imgBg;
        //hoverScript.borderFrame = imgBorda;
        //hoverScript.label = tmpLabel;
    }

    void CriarCantoDecorativo(Transform pai, string nome, Vector2 ancoragem, Vector2 desvioPosicao)
    {
        // Cria uma imagem sutil simulando o detalhe nos cantos internos
        GameObject canto = new GameObject(nome, typeof(RectTransform), typeof(Image));
        canto.transform.SetParent(pai, false);
        
        RectTransform r = canto.GetComponent<RectTransform>();
        r.anchorMin = ancoragem;
        r.anchorMax = ancoragem;
        r.pivot = ancoragem;
        r.sizeDelta = new Vector2(10, 10); // Tamanho ~10x10px do guia
        r.anchoredPosition = desvioPosicao; // Afasta 4px para dentro do botão
        
        canto.GetComponent<Image>().color = ConvertHex("#2E2510");
    }

    void ConfigurarStretchTotal(RectTransform rect)
    {
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    // Utilitário para facilitar o uso das cores Hex do tutorial
    Color ConvertHex(string hex)
    {
        if (ColorUtility.TryParseHtmlString(hex, out Color cor))
        {
            return cor;
        }
        return Color.white;
    }

    #endregion

    #region Funções de Lógica e Transição

    void OnCombater()
    {
        Debug.Log("Carregando cena: CharacterSelect...");
        // UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
    }

    void OnSobre()
    {
        Debug.Log("Acionando painel sobre o projeto...");
    }

    void OnSair()
    {
        Debug.Log("Fechando o Jogo...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    #endregion
}