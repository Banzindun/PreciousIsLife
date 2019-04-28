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

    /* Set the map parameters and place it on the stage */
    public Card Summon(CardDefinition cardDefinition)
    {
        GameObject cardGO = Instantiate(cardPrefab);
        Card card = cardGO.GetComponent<Card>();

        card.SetCardDefinition(cardDefinition);
        card.alive = true;

        card.mainImage.sprite = cardDefinition.image;

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

    // Use this for initialization
    public List<Card> SpawnEnemyCards(BoardPlayer me, BoardPlayer enemy, CardDefinition[] cardsToSpawn)
    {
        return SpawnEnemyCards(me, enemy, cardsToSpawn, enemySpawnPoints);
    }

    private List<Card> SpawnEnemyCards(BoardPlayer me, BoardPlayer enemy, CardDefinition[] cardsToSpawn, GameObject[] spawnPoints)
    {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < cardsToSpawn.Length; i++)
        {
            Card card = Summon(cardsToSpawn[i]);
            card.owner = me;
            card.enemy = enemy;
            card.gameManager = GameManager;

            GameObject cardGO = card.gameObject;

            cardGO.transform.SetParent(spawnPoints[i].transform, false);
            cards.Add(card);
        }

        return cards;
    }

    // Use this for initialization
    public List<Card> SpawnPlayerCards(BoardPlayer me, BoardPlayer enemy, CardDefinition[] cardsToSpawn)
    {
        return SpawnEnemyCards(me, enemy, cardsToSpawn, playerSpawnPoints);
    }
}
