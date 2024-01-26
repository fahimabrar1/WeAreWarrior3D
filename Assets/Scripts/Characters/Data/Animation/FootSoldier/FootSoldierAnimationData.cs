
using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class FootSoldierAnimationData : AnimationDataBase
{
    [BoxGroup("Animation States")]
    [SerializeField] private string meele = "MeeleDownwards";

    [BoxGroup("String To Hashes")]
    public int MeeleHash { get; private set; }

    /// <summary>
    /// We can add more unique varaibles into this foot soldier character class
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();
        MeeleHash = Animator.StringToHash(meele);
    }
}
