using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameSetting GameSettings;

    public PlayerController player;

    public Enemy enemy;

    public int turnNumber;

    // Use this for initialization
    void Start()
    {
        // Get next level
        Level nextLevel = GameSettings.AllLevels[GameSettings.CurrentLevelIndex];

        // Initialize the player
        player.SetState(GameSettings.PlayerState);
        player.GameManager = this;

        SpawnPlayerMonsters(GameSettings.PlayerState.MyCards);
        SpawnEnemyMonsters(nextLevel.cardsToBeSpawned);

        // Show summon dialog if possible
        ShowPlayerSummonDialog();
    }

    private void SpawnEnemyMonsters(CardDefinition[] enemyCards)
    {
        // player.Cards = list of spawned cards
        throw new NotImplementedException();
    }

    private void SpawnPlayerMonsters(CardDefinition[] playerCards)
    {
        // enemy.Cards = list of spawned cards
        throw new NotImplementedException();
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
        turnNumber = 1;
        NewTurn();
        

    }


    public void DoAction(ActionType actionType, Card actorCard, Card targetCard) {
        turnNumber++;
        GameAction.makeAction(this, actionType, actorCard, targetCard);
    }


    public void ActionDone() {
        // Check if any player won
        if (enemy.Lost()) {
            ShowPlayerResurrectDialog();
            return;
        }

        // Check if player lost
        if (player.Lost()) {
            // End the game
            ShowGameOverDialog();
        }

        NewTurn();
    }

   
    private void ShowGameOverDialog()
    {
        throw new NotImplementedException();
    }

    private void ShowPlayerResurrectDialog()
    {
        throw new NotImplementedException();
    }

    public void NewTurn() {
        player.NewTurn(turnNumber);
        enemy.NewTurn(turnNumber);

        // IF AI's turn, then make its turn.
        if (turnNumber % 2 == 0)
        {
            // Should call ActionDone when finished
            enemy.MakeAction(player);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
