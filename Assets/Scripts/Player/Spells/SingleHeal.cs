using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SingleHeal : Spell
{
    public int HealAmount;

    public override void Cast(PlayerController player, Target target)
    {
        Debug.Log("Casting singleHeal spell.");
        Debug.Log("Targets: " + AllTargetsToString(target));

        target.getTargets()[0].Heal(HealAmount);
    }
}
