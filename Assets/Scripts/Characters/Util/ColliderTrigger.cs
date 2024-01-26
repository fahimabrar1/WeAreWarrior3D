using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ColliderTrigger : MonoBehaviour
{

    public SphereCollider sphereCollider;
    public Soldier soldier;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        soldier = GetComponentInParent<Soldier>();
        if (TryGetComponent(out SphereCollider col))
        {
            sphereCollider = col;
            sphereCollider.isTrigger = true;
        }
    }


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(SoldierEnum.Soldier.ToString()))
        {
            if (other.TryGetComponent(out Soldier newSoldier))
            {
                Debug.Log("Triggered");

                if (newSoldier.soldierBase.gameTeam != soldier.soldierBase.gameTeam)
                {
                    //? Why are we casting?
                    //  Each soldier have their own style of attacks, e.g. meele or ranged
                    switch (newSoldier)
                    {
                        case FootSoldier:
                            (newSoldier as FootSoldier).OnAttack();
                            break;

                        case RangedSoldier:
                            (newSoldier as RangedSoldier).OnAttack();
                            break;
                    }
                }
            }
        }

    }
}
