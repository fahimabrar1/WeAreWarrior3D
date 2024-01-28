using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


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


    public static Action<Soldier> OnSoldierDeathAction;


    #region Mono Methods
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        BattleManager.OnNotifyBaseAction += OnNotifyBase;
        OnSoldierDeathAction += OnSoldierDeath;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        BattleManager.OnNotifyBaseAction -= OnNotifyBase;
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
    void Start()
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
        while (true)
        {
            yield return new WaitForSeconds(6);
            SpawnSoldier();
            break;
        }
    }


    /// <summary>
    /// This Method will spawn a soldier inside the bounded box, adding to it's soldier list.
    /// And also notifing the opposite base about this soldier so they can notify their soldiers.
    /// *AND THEY CAN FIGHT TO DEATH
    /// </summary>
    [ShowIf("@this.gameTeam == GameTeamEnums.Player")]
    [Button("Spawn Player")]
    public void SpawnSoldier()
    {
        Vector3 point = RandomPointGenerator.RandomPointInBounds(spawnArea.bounds);
        //Todo: Move data to scriptable object
        var soldier = Instantiate(soldierPrefab, point, Quaternion.identity).GetComponent<Soldier>();
        soldier.soldierBase = this;
        BattleManager.OnNotifyBaseAction(gameTeam, soldier);
        BattleManager.OnNotifySoldierAction();
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
