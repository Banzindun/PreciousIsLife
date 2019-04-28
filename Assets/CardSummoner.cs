using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSummoner : MonoBehaviour {
    public CardDefinition cardDefiniton;

    public void summonMonster() {
        PlayerState.cardHolders.Add(new CardDefinitionHolder(cardDefiniton));
    }

    public void upgradeMonster(CardDefinition oldOne) {
        PlayerState.cardHolders.Remove(new CardDefinitionHolder(oldOne));
        PlayerState.cardHolders.Add(new CardDefinitionHolder(cardDefiniton));

        // TODO check if possible,
       
    }
}
