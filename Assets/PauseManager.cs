using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseHotKeyObject;

    private bool stop;
    public void ConttolPlayer()
    {
        print("���⼭ ESC ������ �÷��̾� ���ߴ� �� Ȯ���ϼ� Find��");
        if (GameObject.Find("MainPlayer(KYHTest)"))
        {
            Player player = GameObject.Find("Player(Test)").GetComponentInChildren<Player>();
            player.isCameraOn = false;
            if (player.isStop)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                player.isStop = false;
                stop = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                player.isStop = true;
                stop = true;
            }
        }
    }
    public void EnalbeEscToPause()
    {
        pauseHotKeyObject.SetActive(true);
    }
}
