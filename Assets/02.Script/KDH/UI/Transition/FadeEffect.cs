using UnityEngine;
using DG.Tweening;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Material fadeMaterial;
    [SerializeField] private float fadeDuration = 1f;
    private float currentAlpha = 0f;

    private static readonly int AlphaProperty = Shader.PropertyToID("_Alpha"); 

    void Start()
    {
        SetAlpha(0f);
    }

    public void FadeIn()
    {
        DOTween.To(() => currentAlpha, x => currentAlpha = x, 1f, fadeDuration)
            .OnUpdate(() => SetAlpha(currentAlpha))
            .OnComplete(() => Debug.Log("FadeEffect �����"));
    }

    public void FadeOut()
    {
        DOTween.To(() => currentAlpha, x => currentAlpha = x, 0f, fadeDuration)
            .OnUpdate(() => SetAlpha(currentAlpha))
            .OnComplete(() => Debug.Log("FadeEffect ���ŵ�"));
    }

    private void SetAlpha(float alpha)
    {
        if (fadeMaterial == null)
        {
            Debug.LogError("FadeMat �����ȵ�");
            return;
        }
        fadeMaterial.SetFloat(AlphaProperty, alpha);
    }
}
