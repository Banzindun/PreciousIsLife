using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Summon : Spell
{
    public override void MissileHit(Card targetCard)
    {
        base.MissileHit(targetCard);
        targetCard.Summon();
    }
}
