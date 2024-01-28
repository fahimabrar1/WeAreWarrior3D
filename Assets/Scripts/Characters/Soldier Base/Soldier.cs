using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(NavMeshObstacle))]
public class Soldier : MonoBehaviour, IDamagable, IAttackable
{
    protected GameTeamEnums gameTeam { get; set; }

    [BoxGroup("Components")]
    [Tooltip("Navigation For the solder")]
    public NavMeshAgent navMeshAgent;

    [BoxGroup("Components")]
    [Tooltip("Navmesh Obstacle, allows agent to act as obstacle during combat, so other agent's won't push it aside")]
    public NavMeshObstacle navMeshObstacle;

    [BoxGroup("Components")]
    [Tooltip("RigidBody of the character")]
    public Rigidbody Rigidbody;

    [BoxGroup("Components")]
    [Tooltip("Animator of the solder")]
    public Animator animator;

    [BoxGroup("Components")]
    [Tooltip("The Collider For detecting objects withi it's range")]
    [Required("Must Attach collider from 'Attack' gameobject ")]
    public SphereCollider sphereCollider;


    [BoxGroup("Data")]
    [Tooltip("The Base of this soldier")]
    public SoldierBase soldierBase;

    [BoxGroup("Data")]
    [Tooltip("Health component of the soldier")]
    public HealthBar healthBar;


    [BoxGroup("Data")]
    public SoldierReusableData soldierReusableData;



    #region Mono Methods
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        animator = GetComponentInChildren<Animator>();
        healthBar = GetComponentInChildren<HealthBar>();
        Rigidbody = GetComponentInChildren<Rigidbody>();
    }


    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        BattleManager.OnNotifySoldierAction += FindClosestTarget;
        BattleManager.OnEndBatleAction += OnEndBatle;
    }



    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        BattleManager.OnNotifySoldierAction -= FindClosestTarget;
        BattleManager.OnEndBatleAction -= OnEndBatle;
    }



    #endregion

    #region Methods

    /// <summary>
    /// Damage the object it is attached to
    /// </summary>
    /// <param name="damage">the damage value passed by the opposite solder</param>
    public virtual void OnDamage(int damage)
    {
    }


    /// <summary>
    /// Attack using the Behavios this soldier can do
    /// </summary>
    public virtual void OnAttack()
    {
    }



    /// <summary>
    /// On Hit Triggers when the weapon is hitted with an enemy
    /// </summary>
    public virtual void OnHitSoldier(Soldier soldier)
    {
    }

    /// <summary>
    /// Move to the destination
    /// </summary>
    public void MoveToDestination()
    {
        if (soldierReusableData.destination != null)
            navMeshAgent.destination = soldierReusableData.destination.position;
    }

    /// <summary>
    /// Finds the closest target, if there are no soldiers then the target is their base 
    /// </summary>
    public void FindClosestTarget()
    {
        ToggleNavAgent(true);
        navMeshAgent.isStopped = false;

        if (!soldierBase.enemies.Any())
        {
            soldierReusableData.closestSoldier = null;
            if (soldierBase.opponentBase != null)
            {
                soldierReusableData.destination = soldierBase.opponentBase.transform;
                Debug.Log($"Set target: {navMeshAgent.speed}");

                return;
            }
        }
        else
        {
            // Return if already engaged with an enemy
            if (soldierReusableData.closestSoldier != null) return;

            soldierReusableData.closestSoldier = soldierBase.enemies
               .OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position))
               .FirstOrDefault();

            if (soldierReusableData.closestSoldier != null)
            {
                soldierReusableData.destination = soldierReusableData.closestSoldier.transform;
            }
            // Handle the case when there are no enemies, or do something else.
            return;
        }
        soldierReusableData.destination = null;
    }


    public void ToggleNavAgent(bool toogle)
    {
        //! never enable both agent and obstacle togehter, else This can lead to erroneous behavior.
        //* making both false to ignore waring and any abnormal behavior
        navMeshAgent.enabled = false;
        navMeshObstacle.enabled = false;

        navMeshObstacle.enabled = !toogle;
        navMeshAgent.enabled = toogle;
    }


    public virtual void OnHitBase(SoldierBase hittedBase)
    {
    }

    public virtual void OnEndBatle()
    {

    }



    #endregion


    #region Events Methods

    public virtual void OnAnimationStarted()
    {
    }

    public virtual void OnAnimationTransition()
    {
    }


    public virtual void OnAnimationEnded()
    {
    }
    #endregion
}
