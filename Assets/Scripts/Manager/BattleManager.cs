using Sirenix.OdinInspector;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [BoxGroup("Soldier Base")]
    [ChildGameObjectsOnly]
    public SoldierBase playerbase;

    [BoxGroup("Soldier Base")]
    [ChildGameObjectsOnly]
    public SoldierBase enemyBase;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerbase.gameTeam = GameTeam.Player;
        enemyBase.gameTeam = GameTeam.Enemy;
    }
}