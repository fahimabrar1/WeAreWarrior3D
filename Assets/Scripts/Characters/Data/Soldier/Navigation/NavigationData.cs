using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class SoldierNavigationData
{
    [BoxGroup("Navigation Parameter")]
    [field: SerializeField] public float Speed { get; set; } = 2f;


    [BoxGroup("Navigation Parameter")]
    [field: Range(10f, 30f)]
    [field: SerializeField] public float Acceleration { get; set; } = 15;


    [BoxGroup("Navigation Parameter")]
    [field: Range(0.05f, 3)]
    [field: SerializeField] public float Radius { get; set; } = 0.2f;
    [BoxGroup("Navigation Parameter")]
    [field: Range(1.5f, 20f)]
    [field: SerializeField] public float StoppingDistance { get; set; } = 2f;


}