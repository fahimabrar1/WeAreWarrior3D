using System;
using UnityEngine;

[Serializable]
public class CombatData
{

}


[Serializable]
public class FootSoldierCombatData : CombatData
{
    [field: Range(1, 10)]
    [field: SerializeField]
    public float CombatRadius { get; set; } = 2f;
}
