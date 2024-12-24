using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadStartLevel());
    }

    public void LoadLevelComplete()
    {
        StartCoroutine(LoadEndLevel());
    }

    IEnumerator LoadStartLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }

    IEnumerator LoadEndLevel()
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);
    }
}
