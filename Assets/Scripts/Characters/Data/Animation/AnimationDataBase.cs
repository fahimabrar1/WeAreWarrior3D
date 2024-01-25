using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class AnimationDataBase
{
    [BoxGroup("Animation Parameters")]
    [InfoBox("Change the THRESHOLD in the blend tree of 'Movement'\n" +
    "the speed should be the same speed of the navmesh agent."
    )]
    [SerializeField] private string speed = "speed";

    [BoxGroup("String To Hashes")]
    public int SpeedHash { get; private set; }


    public virtual void Initialize()
    {
        SpeedHash = Animator.StringToHash(speed);
        Debug.Log(SpeedHash);
    }
}
