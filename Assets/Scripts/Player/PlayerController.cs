using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BoardPlayer
{
    public SpellManager SpellManager;

    public ActionType actionType;

    public bool MakingAction;

    public bool Casting;

    public Spell activeSpell;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            Debug.Log("Player is resetting actions.");
            InterruptInteraction();
        }
    }

    public bool canSummon() {
        Spell summonSpell = SpellManager.getSpell("Summon");

        if (Cards.Count < 3 && SpellManager.isAvailable(summonSpell)) {
            return true;
        }

        return false;
    }

    override public void RemoveCard(Card card)
    {
        // I do not remove cards for the player
        base.RemoveCard(card);
    }

    public override void OnBattleEnd()
    {
        base.OnBattleEnd();

        List<CardDefinitionHolder> cardDefs = new List<CardDefinitionHolder>();

        // TODO Save all the player cards
        foreach (Card card in Cards) {
            if (card.alive)
            {
                cardDefs.Add(new CardDefinitionHolder(card.definition));
            }
        }

        PlayerState.cardHolders = cardDefs;
    }

    override public void Play(Card activeCard) {
        base.Play(activeCard);


        // I should just wait for the player to choose something to do.

    }

    public void OnSpellTrigger(Spell spell) {
        Debug.Log("Spell triggered: " + spell.Name);

        GameManager.ActionManager.SpellTriggered();

        Casting = true;
        this.activeSpell = spell;
    }

    public void OnActionTrigger(ActionType actionType) {
        Debug.Log("Action triggered: " + actionType.ToString());

        SpellManager.ActionTriggered();
        
        // Activate Action selection
        this.actionType = actionType;
        MakingAction = true;

        if (actionType == ActionType.WAIT || actionType == ActionType.BLOCK) {
            // Those two actions do not need target
            GameAction.makeAction(this, actionType, ActiveCard, null);
        }
    }

    override public void OnCardSelected(Card targetCard) {
        Debug.Log("Target card selected: " + targetCard);

        if (MakingAction)
        {
            GameAction.makeAction(this, actionType, ActiveCard, targetCard);
            return;
            
        }

        if (Casting) {
            Target target = new Target();

            if (activeSpell.TargetType == Target.TargetType.ALL)
            {
                foreach (Card c in targetCard.owner.Cards)
                {
                    target.addTarget(c);
                }
            }
            else {
                target.addTarget(targetCard);
            }
            
            SpellManager.castSpell(activeSpell, target);

            return;
        }
    }

    private void FinishedTurn() {
        InterruptInteraction();
    }

    private void InterruptInteraction() {

        GameManager.ActionManager.FinishedTurn();
        SpellManager.FinishedTurn();

        Casting = false;
        MakingAction = false;
    }

    public bool AmITarget(Card card)
    {
        if (Casting) {
            if (this == card.owner && activeSpell.TargetTeam == Target.TargetTeam.FRIEND) {
                return true;
            }

            if (this == card.enemy && activeSpell.TargetTeam == Target.TargetTeam.ENEMY)
            {
                return true;
            }

            return false;
        }

        if (MakingAction)
        {
            if (this == card.owner)
                return false;


            if (card.FrontLineExists() && !card.isAtFrontLine())
            {
                return false;
            }

            // Only action I can be making is Attack, if I am not owner I am targeting an enemy.

            return true;
        }

        return false;
    }

    public bool IsInteracting()
    {
        return Casting || MakingAction;
    }

    public override void OnActionDone()
    {
        base.OnActionDone();
        FinishedTurn();
    }

    public void OnSpellDone() {
        activeSpell = null;
        Casting = false;
        MakingAction = false;
        GameManager.OnSpellDone();
    }
}
