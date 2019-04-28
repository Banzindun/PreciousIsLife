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

        // Something else??

        return true;
    }

    public void castSpell(Spell spell, Target target) {

        // Cast the spell and disable it for the rest of the turn
        spell.Cast(player, target);

        // Spend the health
        PlayerState.health -= spell.HealthCost;
        DisableTurn = player.CurrentTurn;

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
