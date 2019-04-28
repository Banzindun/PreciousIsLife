using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BigDamage : Spell
{
    public int Damage;

    public override void Cast(PlayerController player, Target target)
    {
        Debug.Log("Casting: " + Name);
        Debug.Log("Targets: " + AllTargetsToString(target));

        target.getTargets()[0].ReceiveDamage(Damage);
    }
}
