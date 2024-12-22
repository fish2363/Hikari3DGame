using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseHotKeyObject;

    private bool stop;
    public void ConttolPlayer()
    {
        stop = !stop;
        print("���⼭ ESC ������ �÷��̾� ���ߴ� �� Ȯ���ϼ� Find��");
        if (GameObject.Find("MainPlayer"))
        {
            Player player = GameObject.Find("MainPlayer").GetComponentInChildren<Player>();
            player.isStop = stop;
            player.isCameraOn = false;
            print(player.isStop);
            if (stop)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }
    public void EnalbeEscToPause()
    {
        pauseHotKeyObject.SetActive(true);
    }
}
