using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "WeAreWarrior3D/Level/Level Data", order = 0)]
public class LevelSO : ScriptableObject
{
    public string levelName;
    [InfoBox("Make sure to chose the labels correct")]
    public List<LevelSoldierData> levelSoldiersData;

    [AssetSelector(Paths = "Assets/Resources/Waves")]
    public WaveListSO waveListData;
}



[Serializable]
public class LevelSoldierData
{

    // This price will be used on the upgrade panel
    public int unlockPrice;

    // This price will be used on the upgrade panel and battle scene
    public bool isUnlocked;


    [ValueDropdown("SoldierTypes")]
    public SoldierType soldierType;
    [ValidateInput("HasSameSoldierType", "Data Must have same Soldier Type")]
    [AssetSelector(Paths = "Assets/Resources/Soldier")]
    public SoldierSO soldierData;

    public static IEnumerable<SoldierType> SoldierTypes = Enum.GetValues(typeof(SoldierType)).Cast<SoldierType>();

    /// <summary>
    /// Checks for the same type of soldier, this will be used to fetch the soldier from waves SO
    /// </summary>
    /// <returns></returns>
    private bool HasSameSoldierType()
    {
        return soldierData.SoldierType == soldierType;
    }
}