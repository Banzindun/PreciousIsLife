using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    public GameObject[] enemySpawnPoints;

    public GameObject[] playerSpawnPoints;

    // Use this for initialization
    public List<Card> SpawnEnemyCards(BoardPlayer enemy, CardDefinition[] cardsToSpawn) {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < cardsToSpawn.Length; i++) {
            CardDefinition cd = cardsToSpawn[i];

            GameObject cardGO = Card.Summon(enemy, cd);
            cardGO.transform.SetParent(enemySpawnPoints[i].transform, false);

            cards.Add(cardGO.GetComponent<Card>());
        }

        return cards;
    }

    // Use this for initialization
    public List<Card> SpawnPlayerCards(BoardPlayer enemy, CardDefinition[] cardsToSpawn)
    {
        List<Card> cards = new List<Card>();

        for (int i = 0; i < cardsToSpawn.Length; i++)
        {
            CardDefinition cd = cardsToSpawn[i];

            GameObject cardGO = Card.Summon(enemy, cd);
            cardGO.transform.SetParent(playerSpawnPoints[i].transform, false);

            cards.Add(cardGO.GetComponent<Card>());
        }

        return cards;
    }
}
