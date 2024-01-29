using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;


public class SoldierBase : MonoBehaviour, IDamagable
{


    [BoxGroup("Base Data")]
    public GameTeamEnums gameTeam;

    [BoxGroup("Base Data")]
    public int health;


    [BoxGroup("Base Data")]
    public BoxCollider spawnArea;


    [BoxGroup("Base Data")]
    public SoldierBase opponentBase;

    [BoxGroup("Base Data")]
    [AssetSelector(Paths = "Assets/Prefabs/Soldiers")]
    public GameObject soldierPrefab;

    [BoxGroup("Base Data")]
    public HealthBar healthBar;

    [BoxGroup("Base Data")]
    public ReusableDataBase reusableData;



    [BoxGroup("Soldiers List")]
    [SerializeField]
    public List<Soldier> soldiers = new();

    [BoxGroup("Enemy List")]
    [SerializeField]
    public List<Soldier> enemies = new();

    [ShowIf("@gameTeam==GameTeamEnums.Enemy")]
    public WaveSO waveSO;


    public static Action<Soldier> OnSoldierDeathAction;

    private int currentWave = 0;

    #region Mono Methods
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        BattleManager.OnNotifyBaseAction += OnNotifyBase;
        BattleManager.OnStartBattle += OnStartBattle;
        OnSoldierDeathAction += OnSoldierDeath;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        BattleManager.OnNotifyBaseAction -= OnNotifyBase;
        BattleManager.OnStartBattle -= OnStartBattle;
        OnSoldierDeathAction -= OnSoldierDeath;
    }



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void OnStartBattle()
    {
        reusableData = new()
        {
            //Todo: Fetch from SO
            Health = 100
        };
        healthBar.SetInitialHealth(reusableData.Health);
        if (gameTeam == GameTeamEnums.Enemy)
        {
            //Todo:Initate waves
            StartCoroutine(MakeWaves());
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
    private void OnNotifyBase(GameTeamEnums team, Soldier soldier)
    {
        if (team == gameTeam)
            soldiers.Add(soldier);
        else
            enemies.Add(soldier);
    }



    public virtual void OnDamage(int damage)
    {

        if (reusableData.Health > damage)
        {
            reusableData.Health -= damage;
            healthBar.OnSetHealth(reusableData.Health);
        }
        else
        {
            //Todo: Destroy Base, emmit particles, end battle, fetch coins
            BattleManager.OnEndBatleAction();
            Destroy(gameObject);
        }
    }



    public IEnumerator MakeWaves()
    {
        while (currentWave < GameManager.instance.LevelData.waveListData.waveList.Count)
        {
            waveSO = GameManager.instance.LevelData.waveListData.waveList[currentWave];

            yield return new WaitForSeconds(waveSO.DelayBeforeWave);

            foreach (var soldierType in waveSO.SoldierTypes)
            {
                SpawnSoldier(soldierType);
                yield return new WaitForSeconds(waveSO.SpawningDelay);
            }

            currentWave++;
        }

        //? What if we ran out of list?
    }


    /// <summary>
    /// This Method will spawn a soldier inside the bounded box, adding to it's soldier list.
    /// And also notifing the opposite base about this soldier so they can notify their soldiers.
    /// *AND THEY CAN FIGHT TO DEATH
    /// </summary>
    [ShowIf("@this.gameTeam == GameTeamEnums.Player")]
    [Button("Spawn Player")]
    public void SpawnSoldier(SoldierType soldierType = SoldierType.Foot)
    {
        LevelSoldierData soldierData = GameManager.instance.LevelData.levelSoldiersData
            .Find(data => data.soldierType == soldierType);

        if (soldierData != null)
        {
            Vector3 point = RandomPointGenerator.RandomPointInBounds(spawnArea.bounds);

            // Todo: Move data to scriptable object
            var soldier = Instantiate(soldierData.soldierData.Prefab, point, Quaternion.identity)
                .GetComponent<Soldier>();

            soldier.soldierBase = this;
            BattleManager.OnNotifyBaseAction(gameTeam, soldier);
            BattleManager.OnNotifySoldierAction();
        }
        else
        {
            Debug.LogError("SoldierData not found for SoldierType: " + soldierType);
        }
    }


    private void OnSoldierDeath(Soldier soldier)
    {
        if (soldier.soldierBase.gameTeam == gameTeam)
        {
            soldiers.Remove(soldier);
        }
        else
        {
            enemies.Remove(soldier);
        }
        Destroy(soldier.gameObject);
    }

    #endregion


}
