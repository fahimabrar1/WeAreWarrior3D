
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

    [BoxGroup("Data")]
    public float Speed;

    [BoxGroup("Data")]
    public Transform destination;

    [BoxGroup("Data")]
    public Soldier closestSoldier;
}