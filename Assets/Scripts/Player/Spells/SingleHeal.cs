using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SingleHeal : Spell
{
    public int HealAmount;

    public override void MissileHit(Card targetCard)
    {
        base.MissileHit(targetCard);
        Debug.Log("Casting: " + Name);
    
        targetCard.Heal(HealAmount);
    }
}
