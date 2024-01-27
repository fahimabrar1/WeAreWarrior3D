using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class CombatData
{
    [field: Range(1, 200)]
    [field: SerializeField]
    public int Damage { get; set; } = 4;


    [field: InfoBox("If <b>Meele</b>, make sure the stopping distance is <b>SAME</b> <b>combat</b> radius to ensure contacts.")]
    [field: Range(1, 10)]
    [field: SerializeField]
    public float CombatRadius { get; set; } = 2f;

    [field: Range(1f, 5)]
    [field: SerializeField]
    public float AttackDelay { get; set; } = 2f;


}