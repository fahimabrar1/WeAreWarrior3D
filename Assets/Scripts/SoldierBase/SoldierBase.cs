using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SoldierBase : MonoBehaviour, IDamagable
{


    [BoxGroup("Variables")]
    public GameTeamEnum gameTeam;

    [BoxGroup("Variables")]
    public int health;


    [BoxGroup("Variables")]
    public BoxCollider spawnArea;


    [BoxGroup("Variables")]
    public SoldierBase opponentBase;

    [BoxGroup("Variables")]

    [AssetSelector(Paths = "Assets/Prefabs/Soldiers")]
    public GameObject soldierPrefab;


    [BoxGroup("Soldiers List")]
    [SerializeField]
    public List<Soldier> soldiers = new();

    [BoxGroup("Enemy List")]
    [SerializeField]
    public List<Soldier> enemies = new();


    #region Mono Methods
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        BattleManager.OnNotifyBaseAction += OnNotifyBase;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        BattleManager.OnNotifyBaseAction -= OnNotifyBase;
    }



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (gameTeam == GameTeamEnum.Enemy)
        {
            //Todo:Initate waves
            //StartCoroutine(MakeWaves());
        }
    }


    #endregion

    #region Methods
    /// <summary>
    /// Notifies this base about the opposite base, that the have spawned an enemy
    /// So put it in the list so our solders can lock a closest target to engage with
    /// </summary>
    /// <param name="team">Opposite team tag</param>
    /// <param name="soldier">Can be any type of soldier</param>
    private void OnNotifyBase(GameTeamEnum team, Soldier soldier)
    {
        if (team == gameTeam)
            soldiers.Add(soldier);
        else
            enemies.Add(soldier);

    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    public void OnDamage(int damage)
    {
    }



    public IEnumerator MakeWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            SpawnWave();
        }

    }


    /// <summary>
    /// This Method will spawn a soldier inside the bounded box, adding to it's soldier list.
    /// And also notifing the opposite base about this soldier so they can notify their soldiers.
    /// *AND THEY CAN FIGHT TO DEATH
    /// </summary>
    [ShowIf("@gameTeam == GameTeam.Player")]
    [Button("Spawn Wave/Enemy")]
    public void SpawnWave()
    {

        Vector3 point = RandomPointGenerator.RandomPointInBounds(spawnArea.bounds);
        //Todo: Move data to scriptable object
        var soldier = Instantiate(soldierPrefab, point, Quaternion.identity).GetComponent<Soldier>();
        soldier.soldierBase = this;
        BattleManager.OnNotifyBaseAction(gameTeam, soldier);
        BattleManager.OnNotifySoldierAction();
    }
    #endregion
}
