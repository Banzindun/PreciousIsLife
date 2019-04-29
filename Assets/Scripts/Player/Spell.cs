using System;
using UnityEngine;

public abstract class Spell : ScriptableObject {

    public string Name;

    public Target.TargetType TargetType;

    public Target.TargetTeam TargetTeam;

    public GameObject MissilePrefab;

    public Color effectColor;

    [Tooltip("How much health does the spell cost?")]
    public int HealthCost;

    [NonSerialized]
    public int MissilesCount;

    [NonSerialized]
    public SpellManager SpellManager;

    virtual public void MissileHit(Card targetCard) {
        Debug.Log("Missile hit.");

        MissilesCount--;

        if (MissilesCount <= 0) {
            Debug.Log("Spell done.");
            SpellManager.OnSpellDone();
        }

        // The rest should be implemented in other classes
    }

    protected string AllTargetsToString(Target target) {
        string targetsString = "";
        foreach (Card c in target.getTargets()) {
            targetsString += c.definition.Name + " ";
        }
        return targetsString;
    }

    internal void CreateMissiles(SpellManager spellManager, GameObject missilesParent, PlayerController player, Target target)
    {
        this.SpellManager = spellManager;
        MissilesCount = target.getTargets().Count;

        foreach (Card c in target.getTargets()) {
            // Create the missile
            GameObject missile = GameObject.Instantiate(MissilePrefab);
            missile.transform.SetParent(missilesParent.transform, false);
            missile.transform.localPosition = Vector3.zero;

            Missile missileComponent = missile.GetComponent<Missile>();
            missileComponent.target = c;
            missileComponent.player = player;
            missileComponent.spell = this;

            missileComponent.Launch();
        }        
    }
}
