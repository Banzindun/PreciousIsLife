using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BigDamage : Spell
{
    public int Damage;

    public override void MissileHit(Card targetCard)
    {
        
        Debug.Log("Casting: " + Name);
        targetCard.ReceiveDamage(Damage);
        base.MissileHit(targetCard);
    }
}
