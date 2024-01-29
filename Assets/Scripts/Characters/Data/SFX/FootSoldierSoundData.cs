using System;
using Sirenix.OdinInspector;

[Serializable]
public class FootSoldierSoundData : SoundData
{

    [BoxGroup("Audio Clips")]
    public AudioData OnHit;
}