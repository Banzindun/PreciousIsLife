using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BigDamage : Spell
{
    public int Damage;

    public override void MissileHit(Card targetCard)
    {
        base.MissileHit(targetCard);
        Debug.Log("Casting: " + Name);
        targetCard.ReceiveDamage(Damage);
    }
}
