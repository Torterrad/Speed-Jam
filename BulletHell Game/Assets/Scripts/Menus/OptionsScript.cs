using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    //public PostProcessVolume volume;

    public AudioMixer audioMixer;
    public Slider volumeSlider;

    public float VolumeValue;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", -40f);
    }
    public void Volume(float vol)
    {
        audioMixer.SetFloat("Volume", vol);
            PlayerPrefs.SetFloat("GameVolume", vol);
    }

   // public void Brightness(float brightness)
   // {
        //Target brightness
   // }
}
