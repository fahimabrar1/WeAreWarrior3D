using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class RangedSoldierAnimationData : AnimationDataBase
{
    [BoxGroup("Animation States")]
    [SerializeField] private string throwProjectileState = "Throw";

    [BoxGroup("String To Hashes")]
    public int ThrowProjectileState { get; private set; }

    /// <summary>
    /// We can add more unique varaibles into this foot soldier character class
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        ThrowProjectileState = Animator.StringToHash(throwProjectileState);
    }

}