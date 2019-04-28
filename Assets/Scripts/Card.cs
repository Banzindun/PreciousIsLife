using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // Definition of the card
    public CardDefinition definition;

    public int health; // TODO init the health

    public int level; // TODO init the level

    public bool alive;

    public bool hasShield = false;

    public bool isActiveCard;

    public BoardPlayer owner;

    public BoardPlayer enemy;

    public GameManager gameManager;

    public Text effectLabel;

    public Image mainImage;

    public Image typeImage;

    public GameObject shieldGO;

    public Text hPLabel;

    private void Start()
    {
        UpdateHealthBar();
    }

    /* Set the starting parameters according to the card class definition */
    public void SetCardDefinition(CardDefinition cardDefinition)
    {
        this.definition = cardDefinition;


        health = definition.maxHealth;
        level = definition.level; // TODO init the level
    }

    public void ReceiveDamage(Card otherCard)
    {
        Debug.Log("Receiving damage.");

        CardDefinition otherDef = otherCard.definition;

        // He is attacking me, I receive damage given his type
        // If I have shield, I block something
        double damageReceived = 0;
        switch (definition.type) {
            case CardTypes.Type.Archer:
                damageReceived = otherDef.archerAttackDamage;
                break;
            case CardTypes.Type.Flying:
                damageReceived = otherDef.flyingAttackDamage;
                break;
            case CardTypes.Type.Melee:
                damageReceived = otherDef.meleeAttackDamage;
                break;
            default:
                break;
        }

        if (hasShield)
        {
            damageReceived *= definition.shieldReduction;
            DisableShield();
        }

        Debug.Log("Receiving " + damageReceived + "damage");

        RemoveHealth((int) damageReceived);
    }

    private void RemoveHealth(int damageReceived)
    {
        health -= damageReceived;

        UpdateHealthBar();

        if (health <= 0) {
            Death();
        }
    }

    private void UpdateHealthBar() {
        hPLabel.text = health + "";
    }


    public void LevelUp()
    {
        level++;
    }
    public void Revival()
    {
        alive = true;
    }
    public void Death()
    {
        alive = false;

        // Tell the owner  and gameManager that the card was destroyed
        owner.RemoveCard(this);
        gameManager.RemoveCard(this);

        // TODO: Death effect/animation
    }

    public CardDefinition GetCardDefinitionSignature()
    {
        return CardDefinition.Create(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        ActivateHighlight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        DisableHighlight();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Player clicked on card: " + definition.Name);

            enemy.OnCardSelected(this);
            owner.OnCardSelected(this);
        }
    }

    public void ActivateHighlight() {
        if (hasShield) {
            HighlightShield();
        }

        if (isActiveCard) {
            // Set the highlight for the active card
            HighlightActiveCard();
        }

        if (gameManager.player.IsInteracting())
        {
            if (gameManager.player.AmITarget(this)) {
                effectLabel.text = "Interactable";
                return;
            }

            // TODO set the highlight
            effectLabel.text = "NonInteractable";

            if (isActiveCard)
                return;
        } else {
            effectLabel.text = "HP Displayed";
        }
    }

    public void DisableHighlight()
    {
        effectLabel.text = "";

        if (isActiveCard) {
            HighlightActiveCard();
        }        
    }

    public void HighlightActiveCard() {
        effectLabel.text = "ActiveCard";
    }



    public void NewRound()
    {
        // Reset the shield
        DisableShield();
    }

    internal void HighlightShield()
    {
        shieldGO.SetActive(true);
    }

    internal void DisableShield() {
        hasShield = false;
        shieldGO.SetActive(false);
    }
}