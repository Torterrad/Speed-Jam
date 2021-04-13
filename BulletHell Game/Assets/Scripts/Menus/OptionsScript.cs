using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public PostProcessVolume volume;
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    //private CGM cgm;

    void Start()
    {
        //volume.profile.TryGetSettings(out cgm);
    }
    public void Volume(float vol)
    {
        audioMixer.SetFloat("Volume", vol);
        volumeSlider.value = vol;
    }

   // public void Brightness(float brightness)
   // {
        //Target brightness
   // }
}
