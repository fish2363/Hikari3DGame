using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class CutSceneEffecter : MonoBehaviour
{
    public Image blackImage;
    public CinemachineVirtualCamera virtualCamera;
    public void FadeInBlackImage()
    {
        blackImage.DOFade(1,0.4f);
    }

    public void FadeOutBlackImage()
    {
        blackImage.DOFade(0, 0.4f);
    }

    public void CameraZoomEffect(float i)
    {
        virtualCamera.DOKill();
        DOTween.To(() => virtualCamera.m_Lens.FieldOfView, x => virtualCamera.m_Lens.FieldOfView = x, i, 0.4f).SetEase(Ease.OutQuint);
    }
}
