using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class SoldierSO : ScriptableObject
{
    [BoxGroup("Core Data")]
    public GameObject Prefab;

    [BoxGroup("Core Data")]
    public string SoldierName;

    [BoxGroup("Core Data")]
    public SoldierType SoldierType;

    [BoxGroup("Core Data")]
    public int Health = 4;
}