using UnityEngine;

public class HitTrigger : MonoBehaviour
{

    public Collider Collider;
    public Soldier soldier;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        soldier = GetComponentInParent<Soldier>();
        if (TryGetComponent(out Collider col))
        {
            Collider = col;
            Collider.isTrigger = true;
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
                if (newSoldier.soldierBase.gameTeam == soldier.soldierBase.gameTeam)
                    newSoldier.OnAttack();
            }
        }
    }
}