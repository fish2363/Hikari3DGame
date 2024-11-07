using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscManager : MonoBehaviour
{
    [SerializeField] private GameObject _esc;
    [SerializeField] private GameObject _setting;
    [SerializeField] private List<GameObject> _escGroup = new List<GameObject>();
    private bool _isOpen;

    private void Awake()
    {
        _isOpen = true;
        _esc.SetActive(false);
    }
    private void Update()
    {
        Esc();
    }

    private void Esc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isOpen)
        {
            _esc.SetActive(true);
            _isOpen = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !_isOpen)
        {
            _isOpen = true;
            _escGroup.ForEach(e => e.SetActive(false));
        }
    }

    public void ContinueButton()
    {
        _esc.SetActive(false);
        _isOpen = true;
    }

    public void Setting()
    {
        _setting.SetActive(true);
        _esc.SetActive(false);
    }

    public void SettingQuit()
    {
        _setting.SetActive(false);
        _esc.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
