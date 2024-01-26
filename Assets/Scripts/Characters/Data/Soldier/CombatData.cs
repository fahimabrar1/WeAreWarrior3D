using System;
using UnityEngine;

[Serializable]
public class CombatData
{
    [field: Range(1, 10)]
    [field: SerializeField]
    public float CombatRadius { get; set; } = 2f;

    [field: Range(1f, 5)]
    [field: SerializeField]
    public float AttackDelay { get; set; } = 2f;


}