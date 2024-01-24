using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Soldier : MonoBehaviour, IDamagable, IAttackable
{



    protected GameTeam gameTeam { get; set; }

    [BoxGroup("Components")]
    [Tooltip("Navigation For the solder")]
    public NavMeshAgent navMeshAgent;

    [BoxGroup("Components")]
    [Tooltip("Animator of the solder")]
    public Animator animator;


    [BoxGroup("Data")]

    [Tooltip("Animator parameter name")]
    public AnimationData animationData;

    [BoxGroup("Data")]
    public Transform destinaiton;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }


    /// <summary>
    /// Damage the object it is attached to
    /// </summary>
    /// <param name="damage">the damage value passed by the opposite solder</param>
    public virtual void OnDamage(int damage)
    {
    }


    /// <summary>
    /// Attack using the Behavios this soldier can do
    /// </summary>
    public virtual void OnAttack()
    {
    }

    /// <summary>
    /// Move to the destination
    /// </summary>
    public virtual void MoveToDestination(Vector3 position)
    {
        navMeshAgent.SetDestination(position);
    }
}
