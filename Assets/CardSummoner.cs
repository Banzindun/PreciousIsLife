using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSummoner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public CardDefinition cardDefiniton;

    public Image cardBackground;
    public Image cardImage;
    public Text cardCost;

    // The one that will be spawned/upgraded to etc.
    public CardDefinition activeCard;

    private bool upgradeAvailable;
    private bool summonAvailable;

    // Text tooltip
    public Text tooltip;

    public UnityEvent OnClick;

    private void Start()
    {
        // Check if the player has some unit of the type of the card definition
        CardDefinition def = PlayerState.GetCardOfType(cardDefiniton.type);
        

        if (def == null) {
            // Didn't find ... can summon
            summonAvailable = true;
            upgradeAvailable = false;

            activeCard = cardDefiniton;
        } else {
            // Found one
            if (def.level == 2) {
                // Max level
                upgradeAvailable = false;
                activeCard = def;                
            } else {
                upgradeAvailable = true;
                activeCard = cardDefiniton.nextLevel;
            }

            summonAvailable = false;
        }

        // Check that the player's health is sufficent
        SetupCard(activeCard);

        if (PlayerState.health < activeCard.cost) {
            summonAvailable = false;
        }
    }

    private void SetupCard(CardDefinition def)
    {
        cardBackground.sprite = def.type.backgroundImageNoStats;
        cardCost.text = def.cost + "";
        cardImage.sprite = def.image;

        
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (summonAvailable)
        {
            tooltip.text = "Summon";
            tooltip.enabled = true;
        }
        else if (upgradeAvailable) {
            tooltip.text = "Upgrade";
            tooltip.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (summonAvailable)
        {
            Summon();
            tooltip.enabled = false;
        }
        else if (upgradeAvailable)
        {
            Upgrade();
            tooltip.enabled = false;
        }

        if (summonAvailable || upgradeAvailable) {
            OnClick.Invoke();
        }
    }

    private void Update()
    {
        if (!upgradeAvailable && !summonAvailable) {
            // Disable or smth.
        }
    }


}
