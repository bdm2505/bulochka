using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundValue : MonoBehaviour
{
    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) audioSrc.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("volume");
    }
}
