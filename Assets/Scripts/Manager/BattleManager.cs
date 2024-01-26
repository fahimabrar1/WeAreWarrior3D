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


    public static Action<GameTeamEnum, Soldier> OnNotifyBaseAction;
    public static Action OnNotifySoldierAction;



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerbase.gameTeam = GameTeamEnum.Player;
        playerbase.opponentBase = enemyBase;

        enemyBase.gameTeam = GameTeamEnum.Enemy;
        enemyBase.opponentBase = playerbase;
    }


}