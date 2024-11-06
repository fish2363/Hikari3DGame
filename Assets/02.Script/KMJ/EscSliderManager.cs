using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EscSliderManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;


    private void Awake()
    {
        BackGroundSlider(80);
        VFXSlider(80);
        MainSlider(80);
    }
    public void BackGroundSlider(float value)
    {
        _audioMixer.SetFloat("BackGround", value -= 80);
    }

    public void VFXSlider(float value)
    {
        _audioMixer.SetFloat("VFX", value -= 80);
    }

    public void MainSlider(float value)
    {
        _audioMixer.SetFloat("Main", value -=80);
    }

}
