using UnityEngine;
using DG.Tweening;

public class WipeEffect : MonoBehaviour
{
    [SerializeField] private Material wipeMaterial;
    [SerializeField] private float wipeDuration = 1f;
    private float wipeProgress = 0f;

    public void StartWipe()
    {
        DOTween.To(() => wipeProgress, x => wipeProgress = x, 1f, wipeDuration)
            .OnUpdate(() =>
            {
                wipeMaterial.SetFloat("_WipeProgress", wipeProgress);
            })
            .OnComplete(() =>
            {
                Debug.Log("WipeEffect ½ÇÇàµÊ");
            });
    }
}
