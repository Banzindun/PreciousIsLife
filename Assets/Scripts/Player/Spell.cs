using UnityEngine;

public abstract class Spell : ScriptableObject {

    public string Name;

    public Target.TargetType TargetType;

    public Target.TargetTeam TargetTeam;

    //private int disabledTurnNumber = 0;

    /*public int DisableTurn
    {
        set { disabledTurnNumber = value; }
        get { return disabledTurnNumber; }
    }*/

    [Tooltip("How much health does the spell cost?")]
    public int HealthCost;

    abstract public void Cast(PlayerController player, Target target);

    protected string AllTargetsToString(Target target) {
        string targetsString = "";
        foreach (Card c in target.getTargets()) {
            targetsString += c.definition.Name + " ";
        }
        return targetsString;
    }
}
