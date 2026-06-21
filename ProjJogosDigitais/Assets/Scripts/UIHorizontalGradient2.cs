using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Horizontal Gradient")]
[RequireComponent(typeof(Graphic))]
public class UIHorizontalGradient2 : BaseMeshEffect
{
    [Header("Configuração das Cores")]
    public Color leftColor = new Color(0.067f, 0.063f, 0.031f, 1f); 
    public Color rightColor = new Color(0.541f, 0.439f, 0.188f, 1f); 

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount != 4) return;

        UIVertex bl = new UIVertex(); vh.PopulateUIVertex(ref bl, 0); 
        UIVertex tl = new UIVertex(); vh.PopulateUIVertex(ref tl, 1); 
        UIVertex tr = new UIVertex(); vh.PopulateUIVertex(ref tr, 2); 
        UIVertex br = new UIVertex(); vh.PopulateUIVertex(ref br, 3); 

        bl.color = leftColor;
        tl.color = leftColor;
        tr.color = rightColor;
        br.color = rightColor;

        vh.SetUIVertex(bl, 0);
        vh.SetUIVertex(tl, 1);
        vh.SetUIVertex(tr, 2);
        vh.SetUIVertex(br, 3);
    }
}