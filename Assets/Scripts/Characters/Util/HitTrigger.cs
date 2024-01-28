using Sirenix.OdinInspector;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    [Required]
    public Collider Collider;
    public Soldier soldier;
    public bool isDestroyable;


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
        if (other.gameObject.CompareTag(DefaultEnums.Soldier.ToString()))
        {
            if (other.TryGetComponent(out Soldier newSoldier))
            {
                soldier.OnHitSoldier(newSoldier);
            }
            //Todo: pool it
            if (isDestroyable)
                Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag(DefaultEnums.Base.ToString()))
        {
            if (other.TryGetComponent(out SoldierBase hittedBasesoldierBase))
            {
                soldier.OnHitBase(hittedBasesoldierBase);
            }
            //Todo: pool it
            if (isDestroyable)
                Destroy(gameObject);
        }

    }
}