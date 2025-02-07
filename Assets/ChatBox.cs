using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Playables;
using Cinemachine;

public class ChatBox : MonoBehaviour
{
    [SerializeField]
    private CutSceneEffecter Effector;
    [SerializeField] private CinemachineVirtualCamera forgottenToyscamera;
    [SerializeField] private CinemachineVirtualCamera pencilcamera;
    [SerializeField]
    private TextMeshProUGUI chat;
    [SerializeField]
    private TextMeshProUGUI npcName;
    [SerializeField]
    private CanvasGroup textBox;

    private bool isSkip;

    string[] dialogues;
    int talkNum;

    #region 임시
    public string[] tutorialDialogue;


    public void StartTutorial()
    {
        ShowChatBox();
        SpeakChatbox(tutorialDialogue, "???");
    }
#endregion

    public void ChangeSpeaker(string speaker)
    {
        npcName.text = speaker;
    }

    public void SpeakChatbox(string[] newChat,string Speaker)
    {
        dialogues = newChat;
        npcName.text = Speaker;
        StartCoroutine(TypingRoutine(dialogues[talkNum]));
    }

    IEnumerator TypingRoutine(string talk)
    {
        chat.text = null;

        if (talk.Contains("  ")) talk = talk.Replace("  ","\n");
        if (talk.Contains("ReName"))
        {
            ChangeSpeaker("요정");
            talk = talk.Replace("ReName", " ");
        }
        if (talk.Contains("ZoomIn"))
        {
            Effector.CameraZoomEffect(20);
            talk = talk.Replace("ZoomIn", " ");
        }
        if (talk.Contains("ZoomOut"))
        {
            Effector.CameraZoomEffect(40);
            talk = talk.Replace("ZoomOut", " ");
        }
        if (talk.Contains("Bold"))
        {
            chat.fontStyle = FontStyles.Bold;
            chat.color = Color.red;
            talk = talk.Replace("Bold", " ");
        }
        if (talk.Contains("Normal"))
        {
            chat.fontStyle = FontStyles.Normal;
            chat.color = Color.white;
            talk = talk.Replace("Normal", " ");
        }
        if (talk.Contains("CameraToys"))
        {
            forgottenToyscamera.Priority = 10;
            talk = talk.Replace("CameraToys", " ");
        }

        if (talk.Contains("CameraYojung"))
        {
            forgottenToyscamera.Priority = 0;
            talk = talk.Replace("CameraYojung", " ");
        }

        if (talk.Contains("CameraPencil"))
        {
            pencilcamera.Priority = 10;
            talk = talk.Replace("CameraPencil", " ");
        }

        for (int i =0; i<talk.Length; i++)
        {
            chat.text += talk[i];
            yield return new WaitForSeconds(0.05f);
        }
        isSkip = true;
    }

    private void Update()
    {
        if(isSkip && Input.GetMouseButtonDown(0))
        {
            isSkip = false;
            NextTalk();
        }
    }

    private void NextTalk()
    {
        chat.text = null;
        talkNum++;

        if(talkNum == dialogues.Length)
        {
            EndTalk();
            return;
        }

        StartCoroutine(TypingRoutine(dialogues[talkNum]));
    }

    private void EndTalk()
    {
        talkNum = 0;
        HideChatBox();
    }

    public void HideChatBox()
    {
        DOTween.To(()=> textBox.alpha,x => textBox.alpha = x,0,0.2f);
    }

    public void ShowChatBox()
    {
        DOTween.To(() => textBox.alpha, x => textBox.alpha = x, 1, 0.2f);
    }
}
