using System;
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


    public static Action<GameTeamEnums, Soldier> OnNotifyBaseAction;
    public static Action OnNotifySoldierAction;
    public static Action OnStartBattle;
    public static Action OnEndBatleAction;




    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerbase.gameTeam = GameTeamEnums.Player;
        playerbase.opponentBase = enemyBase;

        enemyBase.gameTeam = GameTeamEnums.Enemy;
        enemyBase.opponentBase = playerbase;
    }


}