using UnityEngine;

[ExecuteInEditMode]
public class DepthEffect : MonoBehaviour
{
    public Material depthMaterial;

    void start(){
        Camera.main.depthTextureMode = DepthTextureMode.Depth;

    }
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        
        if (depthMaterial != null)
        {
            Graphics.Blit(src, dest, depthMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
