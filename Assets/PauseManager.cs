using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseHotKeyObject;

    public void ConttolPlayer(bool stop)
    {
        print("��");
        if (GameObject.Find("�÷��̾������Ʈ�̸�"))
        {
            //Player player = GameObject.Find("�÷��̾������Ʈ�̸�").GetComponent<Player>();
            //player.isStop = stop;
            //print(player.isStop);
            //if (stop)
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //    Cursor.visible = true;
            //    Time.timeScale = 0;
            //}
            //else
            //{
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;
            //    Time.timeScale = 1;
            //}
        }
    }
    public void EnalbeEscToPause()
    {
        pauseHotKeyObject.SetActive(true);
    }
}
