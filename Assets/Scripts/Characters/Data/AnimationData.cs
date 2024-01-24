using System;

using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class AnimationData
{
    [BoxGroup("Parameters")]
    [SerializeField] private string speed = "speed";


    [BoxGroup("String To Hashes")]
    public int Speed { get; private set; }

    public void Initialize()
    {
        Speed = Animator.StringToHash(speed);

    }
}
