using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave List SO", menuName = "WeAreWarrior3D/Wave/Wave List Data", order = 0)]
public class WaveListSO : ScriptableObject
{

    [AssetSelector(Paths = "Assets/Resources/Waves")]
    public List<WaveSO> waveList;
}