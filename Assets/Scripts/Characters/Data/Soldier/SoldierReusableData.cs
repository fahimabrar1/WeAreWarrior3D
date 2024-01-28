
using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class ReusableDataBase
{
    [BoxGroup("Data")]
    public int Health;
}

[Serializable]
public class SoldierReusableData : ReusableDataBase
{
    [BoxGroup("All Soldier Data")]
    public float Speed;

    [BoxGroup("All Soldier Data")]
    public Transform destination;

    [BoxGroup("All Soldier Data")]
    public Soldier closestSoldier;
    [BoxGroup("All Soldier Data")]
    public bool isAttacking;

    [BoxGroup("All Soldier Data")]
    public SoldierBase soldierBaseTarget;

    // For Ranged Soldiers
    [BoxGroup("Ranged Soldier Data")]
    public float ProjectileSpeed;
}