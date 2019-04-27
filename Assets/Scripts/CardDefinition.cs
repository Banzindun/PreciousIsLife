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
    public  Sprite pic1;
    public  Sprite pic2;


    // Function called on each card after a new turn
    public void OnNewTurn() {

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
        def.pic1 = card.pic1;
        def.pic2 = card.pic2;
        return def;
    }
}