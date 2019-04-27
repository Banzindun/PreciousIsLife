using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BoardPlayer
{
    public GameManager GameManager;

    public PlayerState playerState;

    public SpellManager SpellManager;

    public int Health;
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(PlayerState playerState) {
        Health = playerState.Health;
    }

    public bool canSummon() {
        Spell summonSpell = SpellManager.getSpell("Summon");

        if (Cards.Count < 3 && SpellManager.isAvailable(summonSpell)) {
            return true;
        }

        return false;
    }

    override public void RemoveCard(Card card)
    {
        // I do not remove cards for the player
        base.RemoveCard(card);
        
    }


    public override void OnBattleEnd()
    {
        base.OnBattleEnd();

        List<CardDefinition> cardDefs = new List<CardDefinition>();

        // Save all the player cards
        foreach (Card card in Cards) {
            cardDefs.Add(CardDefinition.Create(card));
        }

        playerState.MyCards = cardDefs.ToArray();
        playerState.Health = Health;
    }
}
