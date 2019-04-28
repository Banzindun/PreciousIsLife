using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CardDefinition : ScriptableObject
{
    // Constants:
    public CardTypes.Type type;
    public string Name;
    public int maxHealth;
    public int level;
    public int initiative;

    [Range(0, 1)]
    public double shieldReduction;


    // Damages against different kinds of monsters:
    public int meleeAttackDamage;
    public int archerAttackDamage;
    public int flyingAttackDamage;

    // Image of the card
    public Sprite image;

    public CardDefinition() {

    }

    public CardDefinition(CardDefinition other) {
        type = other.type;
        Name = other.Name;
        maxHealth = other.maxHealth; // .
        level = other.level; // .

        shieldReduction = other.shieldReduction; // .
        meleeAttackDamage = other.meleeAttackDamage; // .
        archerAttackDamage = other.archerAttackDamage; // .
        flyingAttackDamage = other.flyingAttackDamage; // .

        image = other.image; // .
    }

    // Function called on each card after a new turn
    public void OnNewTurn()
    {

    }

    internal static CardDefinition Create(Card card)
    {
        CardDefinition def = new CardDefinition(card.definition);
    
        // TODO if upgraded, should be done directly by changing card definition
        // This might be redundant

        return def;
    }
}