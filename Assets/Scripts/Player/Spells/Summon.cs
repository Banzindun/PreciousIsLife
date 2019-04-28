using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Summon : Spell
{
    public override void Cast(PlayerController player, Target target)
    {
        Debug.Log("Casting summon spell.");
        Debug.Log("Targets: " + AllTargetsToString(target));

        target.getTargets()[0].Summon();
    }
}
