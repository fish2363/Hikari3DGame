using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField]
    private string nameScene;
    [SerializeField] private Image blackImage;
    [SerializeField] private Image vinette;
    [SerializeField] private GameObject filter;
    [SerializeField] private PlayableDirector startTimeLine;
    private CinemachineBasicMultiChannelPerlin noise;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioSource bgm;


    private CanvasGroup canvasGroup;

    private void Start()
    {
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPlayButton()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.DOFade(0, .5f);
        startTimeLine.Play();
        //이후 작업
        bgm.Stop();
        particleSystem.gameObject.SetActive(false);
        blackImage.GetComponent<FadeEffect>().FadeIn();

        StartCoroutine(SceneMove());
    }
    public void CameraShake()
    {
        noise.m_FrequencyGain=1;
        noise.m_AmplitudeGain =3;
        StartCoroutine(CameraShakeSecond());

    }
    private IEnumerator CameraShakeSecond()
    {
        DOTween.KillAll();
        yield return new WaitForSeconds(1f);
        DOTween.To(() => noise.m_FrequencyGain, x => noise.m_FrequencyGain = x, 0f, 0.5f);
        DOTween.To(() => noise.m_AmplitudeGain, x => noise.m_AmplitudeGain = x, 0f, 0.5f);
    }

    private IEnumerator SceneMove()
    {
        vinette.DOFade(0, 2);
        yield return new WaitForSecondsRealtime(5);
        filter.SetActive(false);
        SceneManager.LoadScene(nameScene);
    }
}
