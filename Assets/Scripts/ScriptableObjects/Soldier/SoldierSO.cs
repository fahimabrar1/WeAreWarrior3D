using System;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class SoldierSO : ScriptableObject
{
    // [HorizontalGroup("Multiple Stacked Boxes/Split")]
    // [VerticalGroup("Multiple Stacked Boxes/Split/Left")]
    // [BoxGroup("Multiple Stacked Boxes/Split/Left/Soldier Data")]
    // [PreviewField(50, ObjectFieldAlignment.Left)]
    [HideLabel]
    [Title("Prefab")]
    [HorizontalGroup("Soldier Data/Split", Width = 150)]
    [VerticalGroup("Soldier Data/Split/Left")]
    [PreviewField(Height = 100, Alignment = ObjectFieldAlignment.Left)]
    public GameObject Prefab;



    [TitleGroup("Soldier Data")]
    [VerticalGroup("Soldier Data/Split/Right")]
    [BoxGroup("Soldier Data/Split/Right/Soldier Data")]
    public int Health = 4;
    [VerticalGroup("Soldier Data/Split/Right")]
    [BoxGroup("Soldier Data/Split/Right/Soldier Data")]
    public string SoldierName;
    [VerticalGroup("Soldier Data/Split/Right")]
    [BoxGroup("Soldier Data/Split/Right/Soldier Data")]
    public SoldierType SoldierType;

}