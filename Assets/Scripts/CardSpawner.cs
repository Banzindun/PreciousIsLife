using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    public GameObject[] enemySpawnPoints;

    public GameObject[] playerSpawnPoints;

    public GameManager GameManager;

    public GameObject cardPrefab;

    // Images:

    public Sprite meleeImage;

    public Sprite archerImage;

    public Sprite flyingImage;

    [Tooltip("How much offset will the enemy be from its starting spawn position.")]
    public Vector3 enemyOffset;

    [Tooltip("How much offset will the player be from its starting spawn position.")]
    public Vector3 playerOffset;


    /* Set the map parameters and place it on the stage */
    public Card Summon(CardDefinition cardDefinition)
    {
        GameObject cardGO = Instantiate(cardPrefab);
        Card card = cardGO.GetComponent<Card>();

        card.SetCardDefinition(cardDefinition);
        card.alive = true;

        card.mainImage.sprite = cardDefinition.image;
        card.backgroundImage.sprite = cardDefinition.backgroundImage;

        Sprite typeImage = meleeImage;
        switch (cardDefinition.type) {
            case CardTypes.Type.Archer:
                typeImage = archerImage;
                break;
            case CardTypes.Type.Flying:
                typeImage = flyingImage;
                break;
            case CardTypes.Type.Melee:
                typeImage = meleeImage;
                break;
            default:
                break;
        }

        card.typeImage.sprite = typeImage;

        return card;
    }


    public List<Card> SpawnEnemyCards(BoardPlayer me, BoardPlayer enemy, CardDefinitionHolder[] enemyCardHolders) {
        return SpawnEnemyCards(me, enemy, enemyCardHolders, enemySpawnPoints, enemyOffset);
    }
    
    private List<Card> SpawnEnemyCards(BoardPlayer me, BoardPlayer enemy, CardDefinitionHolder[] cardHoldersToSpawn, GameObject[] spawnPoints, Vector3 offset)
    {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < cardHoldersToSpawn.Length; i++)
        {
            CardDefinition cardDefinition = cardHoldersToSpawn[i].CardDefinition;
            int index = cardHoldersToSpawn[i].Position;

            Card card = Summon(cardDefinition);
            card.owner = me;
            card.enemy = enemy;
            card.gameManager = GameManager;
            card.slotNumber = index;

            GameObject cardGO = card.gameObject;

            cardGO.transform.SetParent(spawnPoints[index].transform, false);
            cardGO.transform.localPosition = offset;
            cards.Add(card);
        }

        return cards;
    }

    // Use this for initialization
    public List<Card> SpawnPlayerCards(BoardPlayer me, BoardPlayer enemy, CardDefinitionHolder[] cardHolders)
    {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < cardHolders.Length; i++)
        {
            CardDefinition cardDefinition = cardHolders[i].CardDefinition;
            int index = cardHolders[i].Position;

            Card card = Summon(cardDefinition);
            card.owner = me;
            card.enemy = enemy;
            card.gameManager = GameManager;
            card.slotNumber = i;

            GameObject cardGO = card.gameObject;

            cardGO.transform.SetParent(playerSpawnPoints[i].transform, false);
            cardGO.transform.localPosition = playerOffset;
            cards.Add(card);
        }

        return cards;
    }

    // TODO refactor
}
