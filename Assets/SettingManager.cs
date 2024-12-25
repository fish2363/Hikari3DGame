using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingManager : MonoBehaviour
{
    private static SettingManager instance;
    public static SettingManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject settingsManagerObj = new GameObject("SettingsManager");
                instance = settingsManagerObj.AddComponent<SettingManager>();
                DontDestroyOnLoad(settingsManagerObj);
            }
            return instance;
        }
    }

    [Header("Settings")]
    public Dictionary<string, bool> boolSettings = new Dictionary<string, bool>
    {
        { "WayMark", true },
        { "Change", true },

    };
    public float Sensitivity
    {
        get => _sensitivity;
        set => _sensitivity = Mathf.Clamp(value, 0.1f, 10f);
    }

    [SerializeField] private Slider sensitivitySlider;//°¨µµ
    private float _sensitivity = 1.5f;

    public bool LRInversion { get; set; } = true;

    [SerializeField]
    private TextMeshProUGUI text;
    public bool isLine = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject FindGameObjectByName(string name)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == name)
            {
                return obj;
            }
        }

        Debug.LogWarning($"GameObject with name '{name}' not found.");
        return null;
    }
    public void ToggleSettingToOff(string settingName)
    {
        isLine = false;
    }
    public void ToggleSettingToOn(string settingName)
    {
        isLine = true;
    }
    public void SettingFloatValue(int type)
    {
        /*  1 : MouseSensitivity
            2 : Brightness
            3 : Gamma   */
        if (type == 1)
        {
            Sensitivity = sensitivitySlider.value;
            text.text = sensitivitySlider.value.ToString().Substring(0,2);
        }
    }
}
