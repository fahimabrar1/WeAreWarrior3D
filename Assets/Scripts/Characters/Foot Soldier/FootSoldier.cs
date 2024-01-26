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

        // setup the attack sphere collider data
        sphereCollider.isTrigger = true;
        sphereCollider.radius = data.CombatData.CombatRadius;

        // setup navmesh data for soldier
        navMeshAgent.speed = data.NavigationData.Speed;
        navMeshAgent.acceleration = data.NavigationData.Acceleration;
        navMeshAgent.radius = data.NavigationData.Radius;
        navMeshAgent.stoppingDistance = data.NavigationData.StoppingDistance;

        // stoppingDistance
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

        Debug.Log($"Remaining Distance: {navMeshAgent.remainingDistance}");
        if (navMeshAgent.remainingDistance <= data.NavigationData.StoppingDistance + data.NavigationData.Radius * 2)
        {
            // Slow down the agent when it's close to the destination
            float desiredSpeed = Mathf.Lerp(0, navMeshAgent.speed, navMeshAgent.remainingDistance / (data.NavigationData.StoppingDistance + data.NavigationData.Radius * 2));
            navMeshAgent.speed = desiredSpeed;
        }

        animator.SetFloat(data.AnimationData.SpeedHash, navMeshAgent.speed);

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (!navMeshAgent.isStopped)
            MoveToDestination(destination.position);
    }
    #endregion


    #region  Methods
    public override void OnAttack()
    {
        base.OnAttack();
        Debug.Log("Attack");
        navMeshAgent.isStopped = true;
        StartCoroutine(RepeatAttack());

    }


    private IEnumerator RepeatAttack()
    {
        yield return new WaitForSeconds(data.CombatData.AttackDelay);
        animator.Play(data.AnimationData.MeeleHash);
    }


    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
    }


    public override void MoveToDestination(Vector3 position)
    {
        navMeshAgent.destination = position;
    }


    public override void FindClosestTarget()
    {
        base.FindClosestTarget();
    }
    #endregion


    #region  Events Methods
    public override void OnAnimationEnded()
    {
        base.OnAnimationEnded();
        if (closestEnemy != null)
            StartCoroutine(RepeatAttack());
    }
    #endregion


    #region  Trigger Methods

    #endregion

}
