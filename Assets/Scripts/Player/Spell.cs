using UnityEngine;

public abstract class Spell : ScriptableObject {

    public Target.TargetType targetType;

    [Tooltip("How much health does the spell cost?")]
    public int HealthCost;

    abstract public void Cast(PlayerController player, Target target);
}
