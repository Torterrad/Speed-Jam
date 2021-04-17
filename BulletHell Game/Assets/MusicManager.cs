using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource slowmusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            music.volume = 0;
            slowmusic.volume = 0.2f;
        }
        else
        {
            music.volume = 0.2f;
            slowmusic.volume = 0;
        }
    }
}
