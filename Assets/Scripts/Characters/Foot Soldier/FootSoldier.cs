using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class FootSoldier : Soldier
{


    [BoxGroup("Data")]
    [Tooltip("Animator parameter name")]
    public AnimationData animationData;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        FindClosestTarget();
    }



    public override void OnAttack()
    {
        base.OnAttack();
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
        MoveToDestination(destination.position);

    }


}
