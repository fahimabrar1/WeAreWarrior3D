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
        soldier.OnAnimationStarted();
    }

    private void OnAnimationTransition()
    {
        soldier.OnAnimationTransition();
    }


    private void OnAnimationEnded()
    {
        soldier.OnAnimationEnded();
    }

}