using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBase : MonoBehaviour, IDamagable
{

    public List<Soldier> soldiers;

    public GameTeam gameTeam;

    public Stack<IDamagable> damagables = new();

    public void OnDamage(int damage)
    {
    }

}
