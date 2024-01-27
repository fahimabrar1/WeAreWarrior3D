
using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class SoldierReusableData
{
    [BoxGroup("Data")]
    public int Health;

    [BoxGroup("Data")]
    public float Speed;

    [BoxGroup("Data")]
    public Transform destination;

    [BoxGroup("Data")]
    public Soldier closestSoldier;
}