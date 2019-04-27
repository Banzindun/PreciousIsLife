using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellManager {

    [SerializeField]
    public Spell[] AllSpells;

    public PlayerController player;

    public SpellManager(PlayerController pc) {
        player = pc;
    }

    public bool isAvailable(Spell spell)
    {
        if (player.Health < spell.HealthCost)
        {
            return false;
        }

        if (spell.DisableTurn == player.CurrentTurn) {
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
        spell.DisableTurn = player.CurrentTurn;

    }

    public Spell getSpell(string name) {
        for (int i = 0; i < AllSpells.Length; i++) {
            if (AllSpells[i].name.Equals(name))
            {
                return AllSpells[i];

            }
        }
        
        return null;
    }
}
