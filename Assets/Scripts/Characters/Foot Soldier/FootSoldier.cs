using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class FootSoldier : Soldier
{


    [BoxGroup("Data")]
    // [InlineEditor]
    [AssetSelector(Paths = "Assets/Resources/Soldier/Foot Soldier")]
    public FootSoldierSO data;




    #region Mono Methods
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetupSoldierData();
        FindClosestTarget();
    }


    /// <summary>
    /// Sets up all the attributes of the soldier
    /// </summary>
    private void SetupSoldierData()
    {
        // Initialize The animaiton strings to hash
        data.AnimationData.Initialize();

        // Assigning data to reusable obj, so the value on the scriptable object won't change
        soldierReusableData = new()
        {
            Health = data.Health,
            Speed = data.NavigationData.Speed,
        };

        healthBar.SetInitialHealth(soldierReusableData.Health);

        // setup the attack sphere collider data
        sphereCollider.isTrigger = true;
        sphereCollider.radius = data.CombatData.CombatRadius;

        // setup navmesh data for soldier
        Debug.Log($"Setting speed: {soldierReusableData.Speed}");
        navMeshAgent.speed = soldierReusableData.Speed;
        navMeshAgent.acceleration = data.NavigationData.Acceleration;
        navMeshAgent.radius = data.NavigationData.Radius;
        navMeshAgent.stoppingDistance = data.NavigationData.StoppingDistance;
        navMeshAgent.isStopped = true;
        Debug.Log($"All Set: {navMeshAgent.speed}");

    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (navMeshAgent.enabled! && navMeshAgent.remainingDistance > 0 && soldierReusableData.destination != null)
        {
            float stoppingDistance = data.NavigationData.StoppingDistance + data.NavigationData.Radius * 2;

            if (navMeshAgent.remainingDistance <= stoppingDistance)
            {
                // Slow down the agent when it's close to the destination
                float desiredSpeed = Mathf.Lerp(0, soldierReusableData.Speed, navMeshAgent.remainingDistance / stoppingDistance);
                navMeshAgent.speed = desiredSpeed;
            }

            // Set the animation speed based on the agent's speed
            animator.SetFloat(data.AnimationData.SpeedHash, navMeshAgent.speed);
        }
    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (navMeshAgent.enabled && !navMeshAgent.isStopped)
        {
            MoveToDestination();
        }
    }
    #endregion


    #region  Methods
    public override void OnAttack()
    {
        if (navMeshAgent.enabled)
        {
            navMeshAgent.isStopped = true;
        }
        base.OnAttack();
        Debug.Log("Attack");
        StartCoroutine(RepeatAttack());
    }


    private IEnumerator RepeatAttack()
    {
        yield return new WaitForSeconds(data.CombatData.AttackDelay);
        if (soldierReusableData.closestSoldier != null)
            animator.Play(data.AnimationData.MeeleHash);
        else
            FindClosestTarget();
    }


    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
        // Todo: deals damage, play sound and  particles effects
        Debug.Log("Taken damage");
        if (soldierReusableData.Health > damage)
        {
            soldierReusableData.Health -= damage;
        }
        else
        {
            soldierReusableData.closestSoldier = null;
            SoldierBase.OnSoldierDeathAction(this);
        }
        //Todo: Pool it
    }
    #endregion


    #region  Events Methods
    public override void OnAnimationEnded()
    {
        base.OnAnimationEnded();
        if (soldierReusableData.closestSoldier != null)
            StartCoroutine(RepeatAttack());
        else
            FindClosestTarget();
    }
    #endregion


    #region  Trigger Methods
    public override void OnHitSoldier(Soldier soldier)
    {
        base.OnHitSoldier(soldier);
        if (soldier == soldierReusableData.closestSoldier)
            soldierReusableData.closestSoldier.OnDamage(data.CombatData.Damage);
    }
    #endregion

}
