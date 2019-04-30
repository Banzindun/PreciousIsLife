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

    [Tooltip("How much offset will the enemy be from its starting spawn position.")]
    public Vector3 enemyOffset;

    [Tooltip("How much offset will the player be from its starting spawn position.")]
    public Vector3 playerOffset;

    [SerializeField]
    [Tooltip("Spawning card options.")]
    private TweenOptions enablingCardsOptions;

    private int enabledCardCount = 0;

    private int allCardsCount = 0;


    /* Set the map parameters and place it on the stage */
    public Card Summon(CardDefinition cardDefinition)
    {
        GameObject cardGO = Instantiate(cardPrefab);
        Card card = cardGO.GetComponent<Card>();

        card.SetCardDefinition(cardDefinition);
        card.alive = true;

        card.mainImage.sprite = cardDefinition.image;
        card.backgroundImage.sprite = cardDefinition.type.backgroundImage;
        

        Sprite typeImage = cardDefinition.type.typeImage;
        card.typeImage.sprite = typeImage;

        card.cardTags.sprite = cardDefinition.type.HolderBackground;

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

            card.SpawnPointImage = spawnPoints[index].GetComponent<Image>();

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
            
            Card card = Summon(cardDefinition);
            card.owner = me;
            card.enemy = enemy;
            card.gameManager = GameManager;
            card.slotNumber = i;

            card.SpawnPointImage = playerSpawnPoints[i].GetComponent<Image>();

            GameObject cardGO = card.gameObject;

            cardGO.transform.SetParent(playerSpawnPoints[i].transform, false);
            cardGO.transform.localPosition = playerOffset;
            cards.Add(card);
        }

        return cards;
    }


    /// <summary>
    /// Let's the cards slide to its place.
    /// </summary>
    public void EnableAllCards(List<Card> allCards)
    {

        enabledCardCount = 0;
        allCardsCount = allCards.Count;


        // Activate all the cards and their Tween components
        foreach (Card c in allCards)
        {
            //c.gameObject.SetActive(true);

            Tween tween = c.GetComponent<Tween>();
            tween.Initialize(enablingCardsOptions);
            tween.StartVector = c.transform.position;
            tween.enabled = true;
            tween.tweenDelegate = (Vector3 position) => c.transform.localPosition = position;
            tween.EndEvent.AddListener(c.OnCardEnabled);
        }
    }

    public void OnCardEnabled()
    {
        enabledCardCount++;

        if (enabledCardCount == allCardsCount)
        {
            // Spawning ended. Tell the game manager
            GameManager.OnCardsEnabled();
        }
    }
}
