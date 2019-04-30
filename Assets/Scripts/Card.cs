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

    public Image mainImage;

    public Image typeImage;

    public Image backgroundImage;

    public GameObject shieldGO;

    public Text hPLabel;

    public int slotNumber;

    public Image SpawnPointImage;

    public Image cardTags;



    public Animator animator;

    public GameObject ActionEffect;

    public Sprite shieldSprite;

    public Sprite hourglassSprite;

    public bool actionTarget = false;



    // Prefab constants
    public float attackEffectDuration;

    

    public Color attackEffectColor;
    public Color activeCardColor;


    public Text damageDisplayer;

    private ImageHoverScaler ihs;


    private void Start()
    {
        UpdateHealthBar();

        ihs = GetComponent<ImageHoverScaler>();
    }


    public void Heal(int healAmount)
    {
        health += healAmount;

        if (health >= definition.maxHealth)
            health = definition.maxHealth;

        UpdateHealthBar();
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

        RemoveHealth((int) damageReceived);
    }

    public void OnBeeingAttacked() {
        AttackEffect attackEffect = gameObject.AddComponent<AttackEffect>();
        attackEffect.mainImage = mainImage;
        attackEffect.duration = attackEffectDuration;
        attackEffect.effectColor = attackEffectColor;
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
        switch (definition.type.type)
        {
            case CardTypes.TYPE.RANGED:
                value = def.archerAttackDamage;
                break;
            case CardTypes.TYPE.FLYING:
                value = def.flyingAttackDamage;
                break;
            case CardTypes.TYPE.MELEE:
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

    private void OnDestroy()
    {
        if (SpawnPointImage != null)
            SpawnPointImage.enabled = true; 
    }

    public CardDefinition GetCardDefinitionSignature()
    {
        return CardDefinition.Create(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ActivateHighlight();
        

        if (gameManager.player.AmITarget(this))
        {
            ihs.ManualPointerEnter();
        }
    }

    public void OnCardEnabled()
    {
        SpawnPointImage.enabled = false;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DisableHighlight();
        ihs.ManualPointerExit();
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

        if (isActiveCard && gameManager.PlayersTurn) {
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
                    EnableActionHighlight(player.actionType);
                }

                return;
            }

            if (isActiveCard)
                return;
        } else {
            // TODO: Do something when hovered over ?? E.g. the rotation??
        }
    }

    private void EnableActionHighlight(ActionType actionType)
    {
        backgroundImage.color = actionType.effectColor;

        if (actionType.type == ActionType.TYPE.ATTACK) {
            damageDisplayer.text = GetDamage(gameManager.player.ActiveCard) + "";
            damageDisplayer.gameObject.SetActive(true);
        }
    }

    private void HighlightAllFriendlyCards(Spell spell)
    {
        foreach (Card c in owner.Cards) {

            c.ActivateSpellHighlight(spell);
            c.GetComponent<ImageHoverScaler>().ManualPointerEnter();

        }
    }

    private void ActivateSpellHighlight(Spell spell)
    {
        backgroundImage.color = spell.effectColor;
    }

    public void DisableHighlight()
    {
        if (actionTarget)
            return;

        damageDisplayer.text = "";
        damageDisplayer.gameObject.SetActive(false);

        PlayerController player = gameManager.player;

        if (isActiveCard && gameManager.PlayersTurn)
        {
            HighlightActiveCard();
        }
        else {
            DisableCardHighlight();
        }

        if (hasShield) {
            DisableShieldHighlight();
        }

        if (player.IsInteracting() && player.AmITarget(this)){
            if (player.Casting)
            {
                Spell activeSpell = gameManager.player.activeSpell;
                if (activeSpell.TargetType == Target.TargetType.ALL)
                {
                    DisableSpellHighlightOnAllFriendlyCards();
                }
                else
                {
                    DisableCardHighlight();
                }
            }
            else {
                DisableCardHighlight();
            }
        }
    }

    // Disables bacgkround color
    private void DisableCardHighlight()
    {
        if (backgroundImage != null)
            backgroundImage.color = Color.white;
    }

    private void DisableSpellHighlightOnAllFriendlyCards()
    {
        foreach (Card c in owner.Cards) {
            c.DisableCardHighlight();
            c.GetComponent<ImageHoverScaler>().ManualPointerExit();
        }
    }

    public void HighlightActiveCard()
    {
        if (gameManager.PlayersTurn)
            backgroundImage.color = activeCardColor;
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

    internal void Ressurect()
    {
        Debug.Log("On ressurect.");
        alive = true;
        health = definition.maxHealth/2;
        Debug.Log("On ressurect:" + health);
        //animator.enabled = true;
        //animator.SetTrigger("OnRessurect");
        //backgroundImage.color = Color.white;

        gameManager.AddCard(this);
        gameManager.player.Cards.Add(this);
    }

    public void OnCardDiedEvent() {
        PlayerState.AddHealth(definition.cost);
        Destroy(gameObject); // To destroy the card
    }

    public void OnActionDone() {
        actionTarget = false;
        DisableHighlight();
    }

    public void OnMissileHit() {
        actionTarget = false;
        DisableHighlight();
    }
    

    public void OnActionEffectDone() {
        gameManager.player.OnActionDone();
    }

    internal void ShieldUp()
    {
        ActionEffect.SetActive(true);
        ActionEffect.GetComponent<Animator>().enabled = true;
        ActionEffect.GetComponent<Animator>().SetTrigger("Do");
        ActionEffect.GetComponent<Image>().sprite = shieldSprite;
    }

    internal void WaitUp()
    {
        ActionEffect.SetActive(true);
        ActionEffect.GetComponent<Animator>().enabled = true;
        ActionEffect.GetComponent<Animator>().SetTrigger("Do");
        ActionEffect.GetComponent<Image>().sprite = hourglassSprite;
    }

    internal void FakeDie()
    {
        Debug.Log("Faking death.");
        //animator.SetTrigger("OnFakeDeath");
    }
}