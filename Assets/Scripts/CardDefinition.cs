using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CardDefinition : ScriptableObject
{
    // Start parameters
    public CardTypes.Type type;
    public string name;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public Card template;
    public bool gamerTeam;
    public Sprite backgroundImage;
    public Sprite mainImage;
    public Sprite typeImage;


    // Function called on each card after a new turn
    public void OnNewTurn()
    {

    }

    internal static CardDefinition Create(Card card)
    {
        CardDefinition def = new CardDefinition();
        def.type = card.type;
        def.name = card.name;
        def.hP = card.hP;
        def.level = card.level;
        def.attackValue = card.attackValue;
        def.template = card.cardDefinition.template;
        def.gamerTeam = card.gamerTeam;
        def.backgroundImage = card.backgroundImage;
        def.mainImage = card.mainImage;
        return def;
    }
}