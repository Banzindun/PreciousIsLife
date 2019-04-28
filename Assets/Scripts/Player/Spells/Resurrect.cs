using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Resurrect : Spell
{
    public override void MissileHit(Card targetCard)
    {
        base.MissileHit(targetCard);

        targetCard.Ressurect();
    }
}
