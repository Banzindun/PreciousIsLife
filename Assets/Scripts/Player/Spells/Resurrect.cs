using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Resurrect : Spell
{
    public override void MissileHit(Card targetCard)
    {
        PlayerState.health -= HealthCost;

        targetCard.Ressurect();
        base.MissileHit(targetCard);
    }

    override public bool IsAvailable(Target target)
    {
        return target.getTargets()[0].alive;
    }
}
