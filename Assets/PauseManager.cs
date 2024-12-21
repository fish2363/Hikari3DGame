using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseHotKeyObject;

    public void ConttolPlayer(bool stop)
    {
        print("뿅");
        if (GameObject.Find("플레이어오브젝트이름"))
        {
            //Player player = GameObject.Find("플레이어오브젝트이름").GetComponent<Player>();
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
