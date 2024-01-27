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

                if (newSoldier.soldierBase.gameTeam != soldier.soldierBase.gameTeam)
                {
                    newSoldier.OnAttack();
                }
            }
        }

    }
}
