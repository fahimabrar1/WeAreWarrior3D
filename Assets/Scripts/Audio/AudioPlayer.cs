using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class AudioPlayer
{
    public AudioSource audioSource;

    public AudioPlayer(AudioSource audioSource)
    {
        this.audioSource = audioSource;
        audioSource.playOnAwake = false;
    }


    /// <summary>
    /// Play Audio 
    /// </summary>
    /// <param name="data"></param>
    public void PlayAudio(AudioData data)
    {
        if (audioSource != null && data != null)
        {
            audioSource.clip = data.clip;
            audioSource.volume = data.volume;
            audioSource.pitch = data.pitch;
            audioSource.Play();
        }
    }
}
