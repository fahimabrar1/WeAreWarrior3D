using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Foot Soldier SO", menuName = "ScriptableObjetcs/Foot Soldier Data", order = 0)]
[Serializable]
public class FootSoldierSO : SoldierSO
{

    [Title("Soldier Data")]
    [Tooltip("The animatioin data of the foot soldier")]
    [SerializeField]
    public FootSoldierAnimationData AnimationData;


    [Tooltip("The combat data of the foot soldier")]
    [SerializeField]
    public FootSoldierCombatData CombatData;
}