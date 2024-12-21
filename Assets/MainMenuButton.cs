using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField]
    private string nameScene;
    [SerializeField] private Image blackImage;
    [SerializeField] private Image vinette;
    [SerializeField] private GameObject filter;
    [SerializeField] private PlayableDirector startTimeLine;

    [SerializeField] private AudioSource bgm;


    private CanvasGroup canvasGroup;

    private void Start()
    {
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

        blackImage.GetComponent<FadeEffect>().FadeIn();

        StartCoroutine(SceneMove());
    }

    private IEnumerator SceneMove()
    {
        vinette.DOFade(0, 2);
        yield return new WaitForSecondsRealtime(5);
        filter.SetActive(false);
        SceneManager.LoadScene(nameScene);
    }
}
