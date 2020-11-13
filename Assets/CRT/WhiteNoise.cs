using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Camera/White Noise")]
public class WhiteNoise : MonoBehaviour
{
    public Shader shader;
    private Material _material;

    protected Material material
    {
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (shader == null)
            return;
        Graphics.Blit(source, destination, material, 0);
    }
}