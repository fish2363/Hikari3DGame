using UnityEngine;
using DG.Tweening;

public class BlurEffect : MonoBehaviour
{
    [SerializeField] private Material blurMaterial;
    [SerializeField] private float blurDuration = 1f;
    [SerializeField] private float maxBlurStrength = 5f;
    private float currentBlurStrength = 0f;

    private static readonly int BlurStrengthProperty = Shader.PropertyToID("_BlurStrength");

    void Start()
    {
        SetBlurStrength(0f);
    }

    public void ApplyBlur()
    {
        DOTween.To(() => currentBlurStrength, x => currentBlurStrength = x, maxBlurStrength, blurDuration)
            .OnUpdate(() => SetBlurStrength(currentBlurStrength))
            .OnComplete(() => Debug.Log("BlurEffect Àû¿ëµÊ"));
    }

    public void RemoveBlur()
    {
        DOTween.To(() => currentBlurStrength, x => currentBlurStrength = x, 0f, blurDuration)
            .OnUpdate(() => SetBlurStrength(currentBlurStrength))
            .OnComplete(() => Debug.Log("BlurEffect Á¦°ÅµÊ"));
    }

    private void SetBlurStrength(float strength)
    {
        if (blurMaterial == null)
        {
            Debug.LogError("BlurMat ¼³Á¤¾ÈµÊ");
            return;
        }
        blurMaterial.SetFloat(BlurStrengthProperty, strength);
    }
}
