using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameSetting GameSettings;

    public PlayerController player;

    public int turnNumber;

    List<Card> enemyCards;

    List<Card> playerCards;

    // Use this for initialization
    void Start()
    {
        // Get next level
        Level nextLevel = GameSettings.AllLevels[GameSettings.CurrentLevelIndex];

        // Initialize the player
        player.SetState(GameSettings.PlayerState);

        // Spawn all the monsters
        SpawnMonsters(nextLevel.cardsToBeSpawned, player.MyCards);

        // Show summon dialog if possible
        ShowPlayerSummonDialog();
    }


    public void SpawnMonsters(CardDefinition[] enemyCards, Card[] myCards) {
        // TODO
    }

    public void ShowPlayerSummonDialog() {
        
        if (!player.canSummon())
        {
            OnPlayerSummonDialogClosed();
            return;
        }

        // TODO: show the dialog
    }

    public void OnPlayerSummonDialogClosed() {
        // Summoning over

        // ...

        // Enable all the monsters and start the game
        EnableAllTheMonsters();
    }


    private void EnableAllTheMonsters()
    {
        // TODO Enable all the monsters


    }

    public void OnMonstersEnabled()
    {
        // TODO Start the game
        StartGame();
    }

    public void StartGame() {
        turnNumber = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
