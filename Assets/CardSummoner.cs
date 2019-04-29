using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSummoner : MonoBehaviour
{
    public CardDefinition cardDefiniton;

    public Image cardBackground;
    public Image cardImage;
    public Text cardCost;

    public Button upgradeButton;
    public Button summonButton;

    // The one that will be spawned/upgraded to etc.
    public CardDefinition activeCard;

    private void Start()
    {
        // Check if the player has some unit of the type of the card definition
        CardDefinition def = PlayerState.GetCardOfType(cardDefiniton.type);
        

        if (def == null) {
            // Didn't find ... can summon
            EnableSummon();
            DisableUpgrade();

            activeCard = cardDefiniton;
        } else {
            // Found one
            if (def.level == 2) {
                // Max level
                DisableUpgrade();
                activeCard = def;                
            } else {
                EnableUpgrade();
                activeCard = cardDefiniton.nextLevel;
            }

            DisableSummon();
        }

        // Check that the player's health is sufficent
        SetupCard(activeCard);

        if (PlayerState.health < activeCard.cost) {
            DisableSummon();
        }
    }

    private void SetupCard(CardDefinition def)
    {
        cardBackground.sprite = def.type.backgroundImageNoStats;
        cardCost.text = def.cost + "";
        cardImage.sprite = def.image;

        
    }

    private void DisableUpgrade()
    {
        upgradeButton.interactable = false;
    }

    private void DisableSummon()
    {
        summonButton.interactable = false;
    }

    private void EnableSummon()
    {
        summonButton.interactable = true;
    }

    private void EnableUpgrade()
    {
        upgradeButton.interactable = true;
    }

    public void Summon()
    {
        PlayerState.cardHolders.Add(new CardDefinitionHolder(activeCard));
        PlayerState.health -= cardDefiniton.cost;
    }

    public void Upgrade()
    {
        PlayerState.cardHolders.Remove(new CardDefinitionHolder(cardDefiniton));
        PlayerState.cardHolders.Add(new CardDefinitionHolder(activeCard));
        PlayerState.health -= cardDefiniton.cost;
    }
}
