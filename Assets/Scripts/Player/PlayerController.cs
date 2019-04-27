using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerState playerState;

    public SpellManager SpellManager;

    public MonsterManager MonsterManager;

    public int Health;

    public int CurrentTurn = 0;

    public Card[] MyCards;


    // Use this for initialization
    void Start () {
        SpellManager = new SpellManager(this);
        MonsterManager = new MonsterManager();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetState(PlayerState playerState) {
        Health = playerState.Health;
        MyCards = playerState.MyCards;
    }

    public bool canSummon() {
        Spell summonSpell = SpellManager.getSpell("Summon");

        if (MyCards.Length < 3 && SpellManager.isAvailable(summonSpell)) {
            return true;
        }

        return false;
    }
}
