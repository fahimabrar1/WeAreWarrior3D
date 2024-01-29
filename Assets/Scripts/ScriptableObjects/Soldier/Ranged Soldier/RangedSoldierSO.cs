using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged Soldier SO", menuName = "WeAreWarrior3D/Soldier/Ranged Soldier SO", order = 1)]
public class RangedSoldierSO : SoldierSO
{
    [VerticalGroup("Soldier Data/Split/Right")]
    [BoxGroup("Soldier Data/Split/Right/Soldier Data")]
    [PreviewField(Alignment = ObjectFieldAlignment.Left)]
    public GameObject Projectile;


    [BoxGroup("Navigation Data")]
    [Tooltip("The animatioin data of the ranged soldier")]
    public SoldierNavigationData NavigationData;

    [BoxGroup("Animaiton Data")]
    [Tooltip("The animatioin data of the ranged soldier")]
    public RangedSoldierAnimationData AnimationData;

    [BoxGroup("Combat Data")]
    [Tooltip("The combat data of the ranged soldier")]
    public RangedSoldierCombatData CombatData;
    [Tooltip("The combat data of the ranged soldier")]
    public RangedSoldierSoundData SoundData;

    public RangedSoldierSO()
    {
        SoldierType = SoldierType.Ranged;
    }
}