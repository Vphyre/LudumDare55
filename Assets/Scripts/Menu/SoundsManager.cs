using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] public Slider sliderSound;
    [SerializeField] public Slider sliderMusic;
    public void SetSound()
    {
        PlayerPrefs.SetFloat("soundVolume", sliderSound.value);
        var sound = PlayerPrefs.GetFloat("soundVolume");
        Debug.Log(sound);
    }
    public void SetMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", sliderMusic.value);
        var volume = PlayerPrefs.GetFloat("musicVolume");

        Debug.Log(volume);
    }
}
