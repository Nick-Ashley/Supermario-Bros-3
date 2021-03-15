using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


[RequireComponent(typeof(Toggle))]
public class SetVolume : MonoBehaviour
{
    public Toggle AudioToggle;
    public AudioMixer mixer;

     void Start()
    {
        AudioToggle = GetComponent<Toggle>();

        if (AudioListener.volume == 0)
        {
            AudioToggle.isOn = false;
        }
    }
    


    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void ToggleAudio(bool audioIn)
    {
        if (audioIn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        };

    }
}
