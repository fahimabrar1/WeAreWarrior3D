using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Soldier soldier;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        soldier = GetComponentInParent<Soldier>();
    }



    private void OnAnimationStarted()
    {
    }

    private void OnAnimationTransition()
    {
    }


    private void OnAnimationEnded()
    {
        if (soldier is FootSoldier footSoldier)
        {
            footSoldier.OnAnimationEnded();
        }
        else if (soldier is RangedSoldier rangedSoldier)
        {
            rangedSoldier.OnAnimationEnded();
        }
    }

}