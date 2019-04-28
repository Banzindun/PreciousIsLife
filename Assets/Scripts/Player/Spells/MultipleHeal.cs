using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MultipleHeal : Spell
{

    public int HealAmount;

    public override void Cast(PlayerController player, Target target)
    {
        Debug.Log("Casting: " + Name);
        Debug.Log("Targets: " + AllTargetsToString(target));

        foreach (Card c in target.getTargets()) {
            c.Heal(HealAmount);
        }
    }
}
