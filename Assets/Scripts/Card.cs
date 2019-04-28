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

    public int health;

    public int level;

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

    public int slotNumber;

    public GameObject attackEffect;

    public GameObject blockEffect;

    public GameObject waitEffect;

    public GameObject activeCardEffect;

    public GameObject deathEffect;

    public GameObject healEffect;

    public GameObject damageEffect;

    private void Start()
    {
        UpdateHealthBar();
    }


    public void Heal(int healAmount)
    {
        health += healAmount;

        UpdateHealthBar();

        if (health > 100)
            health = 100;

        //Instantiate(healEffect, transform.position, Quaternion.identity);
    }

    /* Set the starting parameters according to the card class definition */
    public void SetCardDefinition(CardDefinition cardDefinition)
    {
        definition = cardDefinition;
        health = cardDefinition.maxHealth;
        level = cardDefinition.level; 
    }

    public void ReceiveDamage(Card otherCard)
    {
        Debug.Log("Receiving damage.");

        // He is attacking me, I receive damage given his type
        // If I have shield, I block something
        double damageReceived = GetDamage(otherCard);

        // We have used the shield
        if (hasShield)
        {
            DisableShield();
        }

        Debug.Log("Receiving " + damageReceived + "damage");

        RemoveHealth((int)damageReceived);
    }

    public void ReceiveDamage(int damage)
    {
        RemoveHealth(damage);
    }

    /// <summary>
    /// Damage of other card against me.
    /// </summary>
    public double GetDamage(Card card)
    {
        CardDefinition def = card.definition;

        double value = 0;
        switch (definition.type)
        {
            case CardTypes.Type.Archer:
                value = def.archerAttackDamage;
                break;
            case CardTypes.Type.Flying:
                value = def.flyingAttackDamage;
                break;
            case CardTypes.Type.Melee:
                value = def.meleeAttackDamage;
                break;
            default:
                break;
        }

        if (hasShield)
        {
            value *= definition.shieldReduction;
        }

        return value;
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

    public void Death()
    {
        alive = false;

        // Tell the owner  and gameManager that the card was destroyed
        owner.RemoveCard(this);
        gameManager.RemoveCard(this);

        /*gameObject.AddComponent<TriangleExplosion>();
        StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));*/

        // TODO: Death effect/animation
    }

    public CardDefinition GetCardDefinitionSignature()
    {
        return CardDefinition.Create(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ActivateHighlight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DisableHighlight();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Player clicked on card: " + definition.Name);

            PlayerController player = gameManager.player;

            if (player.IsInteracting())
            {
                if (player.AmITarget(this))
                {
                    enemy.OnCardSelected(this);
                    owner.OnCardSelected(this);
                }
            }
        }
    }

    internal bool isAtFrontLine()
    {
        foreach (Card c in owner.Cards)
        {
            if (c.slotNumber >= 3)
            {
                if (c == this)
                    return true;
            }
        }

        return false;
    }

    internal bool FrontLineExists()
    {
        foreach (Card c in owner.Cards){
            if (c.slotNumber >= 3) {
                return true;
            }
        }

        return false;
    }

    public void ActivateHighlight() {
        if (hasShield) {
            HighlightShield();
        }

        if (isActiveCard) {
            // Set the highlight for the active card
            HighlightActiveCard();
        }

        PlayerController player = gameManager.player;

        if (player.IsInteracting())
        {
            if (player.AmITarget(this)) {

                if (player.Casting)
                {
                    Spell activeSpell = gameManager.player.activeSpell;
                    if (activeSpell.TargetType == Target.TargetType.ALL) {
                        HighlightAllFriendlyCards(activeSpell);
                    }
                    else
                    {
                        ActivateSpellHighlight(activeSpell);
                    }

                }
                else if (gameManager.player.MakingAction) {
                    // Check if there are soldier in row in the first row that aren't me

                    

                    effectLabel.text = "Interactable";
                }

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

    private void HighlightAllFriendlyCards(Spell spell)
    {
        foreach (Card c in owner.Cards) {
            c.ActivateSpellHighlight(spell);
        }
    }

    private void ActivateSpellHighlight(Spell spell)
    {
        effectLabel.text = spell.Name;
    }

    public void DisableHighlight()
    {
        effectLabel.text = "";

        PlayerController player = gameManager.player;

        if (isActiveCard)
        {
            HighlightActiveCard();
        }

        if (hasShield) {
            DisableShieldHighlight();
        }

        if (player.IsInteracting() && player.AmITarget(this) && player.Casting) {
            Spell activeSpell = gameManager.player.activeSpell;
            if (activeSpell.TargetType == Target.TargetType.ALL)
            {
                DisableSpellHighlightOnAllFriendlyCards();
            }
            else
            {
                DisableSpellHighlight();
            }
        }
    }

    private void DisableSpellHighlight()
    {
        effectLabel.text = "";
    }

    private void DisableSpellHighlightOnAllFriendlyCards()
    {
        foreach (Card c in owner.Cards) {
            c.DisableSpellHighlight();
        }
    }

    public void HighlightActiveCard()
    {
        effectLabel.text = "ActiveCard";
        //Instantiate(activeCardEffect, transform.position, Quaternion.identity);
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
        DisableShieldHighlight();
    }

    internal void DisableShieldHighlight() {
        shieldGO.SetActive(false);
    }




    // True if I can kill the other card
    public bool CanKill(Card card) {

        double myDamage = card.GetDamage(this);

        if (myDamage > card.health) {
            return true;
        }

        return false;
    }


    internal void Summon()
    {

        // TODO
        throw new NotImplementedException();
    }

    internal void Ressurect()
    {
        alive = true;

        // TODO: Again enable the card
    }
}