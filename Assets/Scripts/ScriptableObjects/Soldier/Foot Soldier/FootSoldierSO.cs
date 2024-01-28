using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Foot Soldier SO", menuName = "WeAreWarrior3D/Soldier/Foot Soldier Data", order = 0)]
[Serializable]
public class FootSoldierSO : SoldierSO
{
    [Title("Soldier Data")]
    [Tooltip("The animatioin data of the foot soldier")]
    public SoldierNavigationData NavigationData;

    [Tooltip("The animatioin data of the foot soldier")]
    public FootSoldierAnimationData AnimationData;

    [Tooltip("The combat data of the foot soldier")]
    public CombatData CombatData;


    public FootSoldierSO()
    {
        SoldierType = SoldierType.Foot;
    }

}