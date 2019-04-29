using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour{
    
    public Spell[] AllSpells;

    public PlayerController player;

    public SpellActivator[] spellActivators;

    public int DisableTurn = 0;

    public ActionManager actionManager;

    // Parent where we store the missiles
    public GameObject MissilesParent;

    private void Start()
    {
        // To make sure only those I can use are enabled
        //DisableSpells();
        //EnableSpells();
    }

    public SpellManager(PlayerController pc) {
        player = pc;
    }

    internal void ActivateSpell(SpellActivator spellActivator, Spell spell)
    {
        if (!isAvailable(spell)) {
            Debug.LogWarning("Activated spell that is not available.");
        }

        player.OnSpellTrigger(spell);
    }

    public bool isAvailable(Spell spell)
    {
        if (PlayerState.health < spell.HealthCost)
        {
            return false;
        }

        if (DisableTurn == player.CurrentTurn) {
            return false;
        }

        
        // What other requirements??
        // Check the availability there

        return true;
    }

    public bool isAvailable(Target target, Spell spell) {
        if (!isAvailable(spell))
            return false;

        if (target.targetTeam != spell.TargetTeam) {
            return false;    
        }

        Card card = target.getTargets()[0];

        if (player == card.owner && spell.TargetTeam == Target.TargetTeam.ENEMY)
        {
            return false;
        } else if (player == card.enemy && spell.TargetTeam == Target.TargetTeam.FRIEND)
        {
            return false;
        }

        // Something else??

        return spell.IsAvailable(target);
    }

    public void castSpell(Spell spell, Target target) {
        // Create the missile(s) and release them
        spell.CreateMissiles(this, MissilesParent, player, target);
        
        // Cast will be called from the missile??
        //spell.Cast(player, target);

        // Spend the health
        PlayerState.health -= spell.HealthCost;
        DisableTurn = player.CurrentTurn;
    }

    public void OnSpellDone() {
        // To filter out those I cannot cast
        DisableSpells();
        EnableSpells();

        player.OnSpellDone();
    }

    public Spell getSpell(string name) {
        if (AllSpells == null)
            return null;

        for (int i = 0; i < AllSpells.Length; i++) {
            if (AllSpells[i].name.Equals(name))
            {
                return AllSpells[i];
            }
        }
        
        return null;
    }

    internal void ActionTriggered()
    {
        DisableSpells();
    }

    private void DisableSpells() {
        foreach (SpellActivator sa in spellActivators) {
            sa.Deactivate();
        }
    }

    private void EnableSpells()
    {
        foreach (SpellActivator sa in spellActivators)
        {
            if (isAvailable(sa.Spell)) {
                sa.Activate();
            }            
        }
    }

    internal void FinishedTurn()
    {
        EnableSpells();
    }
}
