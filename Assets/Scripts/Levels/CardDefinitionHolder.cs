using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardDefinitionHolder{
    public int Position;
    public CardDefinition CardDefinition;


    public CardDefinitionHolder(CardDefinition def)
    {
        this.CardDefinition = def;
    }

    public override bool Equals(object obj)
    {
        var holder = obj as CardDefinitionHolder;

        if (holder == null)
        {
            return false;
        }

        return this.CardDefinition.Equals(holder.CardDefinition);
    }

    public override int GetHashCode()
    {
        return CardDefinition.GetHashCode();
    }
}
