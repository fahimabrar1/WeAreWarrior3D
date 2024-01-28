using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged Soldier SO", menuName = "WeAreWarrior3D/Soldier/Ranged Soldier SO", order = 1)]
public class RangedSoldierSO : SoldierSO
{
    [BoxGroup("Core Data")]
    public GameObject Projectile;

    [Title("Soldier Data")]
    [Tooltip("The animatioin data of the ranged soldier")]
    public SoldierNavigationData NavigationData;

    [Tooltip("The animatioin data of the ranged soldier")]
    public RangedSoldierAnimationData AnimationData;

    [Tooltip("The combat data of the ranged soldier")]
    public CombatData CombatData;


    public RangedSoldierSO()
    {
        SoldierType = SoldierType.Ranged;
    }
}