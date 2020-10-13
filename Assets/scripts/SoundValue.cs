using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundValue : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVol = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVol;
    }
    public void SetVolume(float vol) 
    {
        musicVol = vol;
    }
}
