using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave SO", menuName = "WeAreWarrior3D/Wave/Wave Data", order = 0)]
public class WaveSO : ScriptableObject
{
    public float DelayBeforeWave = 5;
    public float SpawningDelay = 0.35f;
    public List<SoldierType> SoldierTypes;
}