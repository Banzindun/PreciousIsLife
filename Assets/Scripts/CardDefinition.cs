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

    public CardDefinition nextLevel;

    // Image of the card
    public Sprite image;

    public CardDefinition() {

    }
    
    // Function called on each card after a new turn
    public void OnNewTurn()
    {

    }

    internal static CardDefinition Create(Card card)
    {
        CardDefinition def = ScriptableObject.CreateInstance<CardDefinition>();
        def.Initialize(card.definition);

        // TODO if upgraded, should be done directly by changing card definition
        // This might be redundant

        return def;
    }

    private void Initialize(CardDefinition other)
    {
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
}