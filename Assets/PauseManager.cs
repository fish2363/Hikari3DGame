using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseHotKeyObject;

    public void ConttolPlayer(bool stop)
    {
        print("���⼭ ESC ������ �÷��̾� ���ߴ� �� Ȯ���ϼ� Find��");
        if (GameObject.Find("MainPlayer"))
        {
            Player player = GameObject.Find("MainPlayer").GetComponent<Player>();
            player.isStop = stop;
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
