using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipUI : MonoBehaviour
{
    private float skipGage;
    [SerializeField]
    private Image skipGageBar;
    [SerializeField] private TextMeshProUGUI skipText;

    void Update()
    {
        skipGageBar.GetComponent<RectTransform>().localScale = new Vector3(skipGage, skipGageBar.transform.localScale.y, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            if (skipGage > 8)
            {
                SceneManager.LoadScene("Stage1");
                skipGageBar.gameObject.SetActive(false);
            }
            else
            {
                skipGage += Time.deltaTime * 2;
                skipGageBar.GetComponent<Image>().DOFade(1, skipGage);
                skipText.DOFade(0, 0.2f);
            }
        }
        else
        {
            if (skipGage > 0)
            {
                skipGage -= Time.deltaTime * 3;
                skipGageBar.GetComponent<Image>().DOFade(0, skipGage);
                skipText.DOFade(1, 0.2f);
            }
        }
    }
}
