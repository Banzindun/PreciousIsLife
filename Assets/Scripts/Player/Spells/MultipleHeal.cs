using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MultipleHeal : Spell
{

    public int HealAmount;

    public override void MissileHit(Card targetCard)
    {
        base.MissileHit(targetCard);

        targetCard.Heal(HealAmount);
    }
}
