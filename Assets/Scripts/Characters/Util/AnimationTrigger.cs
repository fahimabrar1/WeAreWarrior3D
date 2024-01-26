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
        //? Why are we casting?
        //  Each soldier have their own style of attacks, e.g. meele or ranged
        switch (soldier)
        {

            case FootSoldier:
                (soldier as FootSoldier).OnAnimationEnded();
                break;

            case RangedSoldier:
                (soldier as RangedSoldier).OnAnimationEnded();
                break;
        }

    }

}