using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class SoundData
{
    [BoxGroup("Audio Clips")]
    public AudioData OnDestroy;
}


[Serializable]
public class AudioData
{
    public AudioClip clip;
    public float volume = 1;
    public float pitch = 1;
}