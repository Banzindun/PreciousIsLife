using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BigDamage : Spell
{
    public override void Cast(PlayerController player, Target target)
    {
        Debug.Log("Casting BigDamage.");
    }
}
