using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoutMaskUI : Image
{
    public override Material GetModifiedMaterial(Material baseMaterial)
    {
        Material mat = base.GetModifiedMaterial(baseMaterial);
        if (mat != null)
        {
            mat.SetFloat("_StencilComp", (float)CompareFunction.NotEqual);
        }
        return mat;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SetMaterialDirty();
        SetVerticesDirty();
    }
}