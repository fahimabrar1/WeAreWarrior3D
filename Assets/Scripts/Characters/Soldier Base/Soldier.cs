using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Rigidbody))]
public class Soldier : MonoBehaviour, IDamagable, IAttackable
{
    protected GameTeamEnum gameTeam { get; set; }

    [BoxGroup("Components")]
    [Tooltip("Navigation For the solder")]
    public NavMeshAgent navMeshAgent;

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
    public Transform destination;

    [BoxGroup("Data")]
    public Soldier closestEnemy;

    #region Mono Methods
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }



    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        BattleManager.OnNotifySoldierAction += FindClosestTarget;
    }



    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        BattleManager.OnNotifySoldierAction -= FindClosestTarget;
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
        navMeshAgent.isStopped = true;
    }

    /// <summary>
    /// Move to the destination
    /// </summary>
    public virtual void MoveToDestination(Vector3 position)
    {
        navMeshAgent.SetDestination(position);
    }

    /// <summary>
    /// Finds the closest target, if there are no soldiers then the target is their base 
    /// </summary>
    public virtual void FindClosestTarget()
    {
        if (!soldierBase.enemies.Any())
        {
            closestEnemy = null;
            if (soldierBase.opponentBase != null)
            {
                destination = soldierBase.opponentBase.transform;
            }
        }
        else
        {
            // Return if already engaged with an enemy
            if (closestEnemy != null) return;

            closestEnemy = soldierBase.enemies
               .OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position))
               .FirstOrDefault();

            if (closestEnemy != null && closestEnemy.transform != null)
            {
                navMeshAgent.isStopped = false;
                destination = closestEnemy.transform;
            }
            // Handle the case when there are no enemies, or do something else.
        }
    }


    #endregion


    #region Events Methods

    protected virtual void OnAnimationStarted()
    {
    }

    protected void OnAnimationTransition()
    {
    }


    public virtual void OnAnimationEnded()
    {
    }
    #endregion
}
