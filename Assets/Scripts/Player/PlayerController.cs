using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BoardPlayer
{
    public GameManager GameManager;

    public PlayerState playerState;

    public SpellManager SpellManager;

    public MonsterManager MonsterManager;

    public int Health;

    public List<Card> RessurectableCards;
    
    // Use this for initialization
    void Start () {
        MonsterManager = new MonsterManager();
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
        base.RemoveCard(card);
        RessurectableCards.Add(card);
    }
}
