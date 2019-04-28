using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MultipleDamage : Spell
{
    public int Damage;

    public override void Cast(PlayerController player, Target target)
    {

        Debug.Log("Casting: " + Name);
        Debug.Log("Targets: " + AllTargetsToString(target));

        foreach (Card c in target.getTargets())
        {
            c.ReceiveDamage(Damage);
        }
    }
        
}
