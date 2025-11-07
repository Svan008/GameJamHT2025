using UnityEngine;

[ExecuteInEditMode]
public class CompositeParticles : MonoBehaviour
{
    public Camera particlesCamera;
    public Material blendMaterial; // material with "Blend One One"

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (particlesCamera && blendMaterial)
        {
            RenderTexture particlesRT = particlesCamera.targetTexture;
            Graphics.Blit(src, dest);
            Graphics.Blit(particlesRT, dest, blendMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}


//Oliwer