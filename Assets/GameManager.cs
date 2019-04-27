using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameSetting GameSettings;

    public PlayerController player;

    public Enemy enemy;

    public int turnNumber;

    public CardSpawner cardSpawner;

    // Dialog for summoning and upgrades
    public GameObject exorcismDialog;

    // Use this for initialization
    void Start()
    {
        // Get next level
        Level nextLevel = GameSettings.AllLevels[GameSettings.CurrentLevelIndex];

        // Initialize the player
        player.SetState(GameSettings.PlayerState);

        SpawnPlayerMonsters(GameSettings.PlayerState.MyCards);
        SpawnEnemyMonsters(nextLevel.cardsToBeSpawned);

        // Show summon dialog if possible
        ShowPlayerSummonDialog();
    }

    private void SpawnEnemyMonsters(CardDefinition[] enemyCards)
    {
        // player.Cards = list of spawned cards
        enemy.Cards = cardSpawner.SpawnEnemyCards(enemy, enemyCards);
    }

    private void SpawnPlayerMonsters(CardDefinition[] playerCards)
    {
        player.Cards = cardSpawner.SpawnPlayerCards(player, playerCards);
    }

    public void ShowPlayerSummonDialog() {
        Debug.Log("Trying to show the player's summon dialog.");
        
        exorcismDialog.SetActive(true);
        // TODO disable player
    }

    public void OnPlayerSummonDialogClosed() {
        Debug.Log("Summoning over.");
        
        // Summoning over

        // ...

        // Enable all the monsters and start the game
        EnableAllTheMonsters();
    }


    private void EnableAllTheMonsters()
    {
        // TODO Enable all the monsters

        OnMonstersEnabled();
    }

    public void OnMonstersEnabled()
    {
        // TODO Start the game
        StartBattle();
    }

    public void StartBattle() {
        Debug.Log("Started new battle.");
        turnNumber = 1;
        NewTurn();

    }


    public void DoAction(ActionType actionType, Card actorCard, Card targetCard) {
        Debug.Log("Performing action: " + actionType.ToString());

        turnNumber++;
        GameAction.makeAction(this, actionType, actorCard, targetCard);
    }


    public void ActionDone() {
        Debug.Log("Action done.");

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
        Debug.Log("Gameover. Showing gameover screen.");
    }

    private void ShowPlayerResurrectDialog()
    {
        Debug.Log("Player won, trying to show ressuret diaog.");
    }

    public void NewTurn() {
        Debug.Log("Starting new round.");

        player.NewTurn(turnNumber);
        enemy.NewTurn(turnNumber);

        // IF AI's turn, then make its turn.
        if (turnNumber % 2 == 0)
        {
            // Should call ActionDone when finished
            Debug.Log("Waiting for enemy to perform an action.");
            enemy.MakeAction(player);
        }
    }

    public void BattleFinished() {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
