using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Horizontal Gradient Split")]
[RequireComponent(typeof(Graphic))]
public class UIHorizontalGradient : BaseMeshEffect
{
    [Header("Configuração das Cores")]
    public Color edgeColor = new Color(0.067f, 0.063f, 0.031f, 1f); 
    public Color centerColor = new Color(0.541f, 0.439f, 0.188f, 1f); 

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount != 4) return;

        UIVertex bl = new UIVertex(); vh.PopulateUIVertex(ref bl, 0); 
        UIVertex tl = new UIVertex(); vh.PopulateUIVertex(ref tl, 1); 
        UIVertex tr = new UIVertex(); vh.PopulateUIVertex(ref tr, 2); 
        UIVertex br = new UIVertex(); vh.PopulateUIVertex(ref br, 3); 

        UIVertex bm = new UIVertex();
        bm.position = (bl.position + br.position) / 2f;
        bm.uv0 = (bl.uv0 + br.uv0) / 2f;
        bm.color = centerColor; 

        UIVertex tm = new UIVertex();
        tm.position = (tl.position + tr.position) / 2f;
        tm.uv0 = (tl.uv0 + tr.uv0) / 2f;
        tm.color = centerColor; 

        bl.color = edgeColor;
        tl.color = edgeColor;
        tr.color = edgeColor;
        br.color = edgeColor;

        vh.Clear();
        
        vh.AddUIVertexQuad(new UIVertex[] { bl, tl, tm, bm });
        vh.AddUIVertexQuad(new UIVertex[] { bm, tm, tr, br });
    }
}