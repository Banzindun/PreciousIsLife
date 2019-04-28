using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Resurrect : Spell
{
    public override void Cast(PlayerController player, Target target)
    {
        Debug.Log("Casting: " + Name);
        Debug.Log("Targets: " + AllTargetsToString(target));

        target.getTargets()[0].Ressurect();
    }
}
