using System;
using UnityEngine;

[Serializable]
public class SoldierSO : ScriptableObject
{
    public GameObject Prefab;
    public string SoldierName;
    public int Health = 4;
}