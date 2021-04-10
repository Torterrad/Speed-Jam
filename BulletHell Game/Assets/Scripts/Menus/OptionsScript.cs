using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;

    public void Volume(float vol)
    {
        audioMixer.SetFloat("Volume", vol);
    }
}
