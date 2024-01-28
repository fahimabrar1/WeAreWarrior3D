using Sirenix.OdinInspector;
using UnityEngine;

public class RangedSoldierAnimationData : AnimationDataBase
{
    [BoxGroup("Animation States")]
    [SerializeField] private string throwProjectile = "throw";

    [BoxGroup("String To Hashes")]
    public int ThrowProjectileHash { get; private set; }

    /// <summary>
    /// We can add more unique varaibles into this foot soldier character class
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        ThrowProjectileHash = Animator.StringToHash(throwProjectile);
    }

}