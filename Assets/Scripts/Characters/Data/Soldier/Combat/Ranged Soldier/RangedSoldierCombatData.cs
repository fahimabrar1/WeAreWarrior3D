using System;
using UnityEngine;

[Serializable]
public class RangedSoldierCombatData : CombatData
{
    [field: Range(8, 30)]
    [field: SerializeField]
    public float ProjectileSpeed { get; set; } = 2f;
}