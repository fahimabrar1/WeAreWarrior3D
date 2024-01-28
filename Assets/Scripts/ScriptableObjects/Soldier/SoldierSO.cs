using System;
using UnityEngine;

[Serializable]
public class SoldierSO : ScriptableObject
{
    public GameObject Prefab;
    public string SoldierName;
    public SoldierType SoldierType;
    public int Health = 4;
}