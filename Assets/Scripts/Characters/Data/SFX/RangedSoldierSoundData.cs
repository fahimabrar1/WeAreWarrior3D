using System;
using Sirenix.OdinInspector;

[Serializable]
public class RangedSoldierSoundData : SoundData
{

    [BoxGroup("Audio Clips")]
    public AudioData OnThrow;

    [BoxGroup("Audio Clips")]
    public AudioData OnHit;
}