using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BoardPlayer
{
    // The state of the player
    public PlayerState playerState;

    public SpellManager SpellManager;

    public ActionManager ActionManager;

    public int Health;

    private ActionType actionType;

    private bool makingAction;

    private bool casting;

    private Spell activeSpell;

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

    public void SetState(PlayerState playerState) {
        Health = playerState.Health;
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

        List<CardDefinition> cardDefs = new List<CardDefinition>();

        // Save all the player cards
        foreach (Card card in Cards) {
            cardDefs.Add(CardDefinition.Create(card));
        }

        playerState.MyCards = cardDefs.ToArray();
        playerState.Health = Health;
    }

    override public void Play(Card activeCard) {
        base.Play(activeCard);


        // I should just wait for the player to choose something to do.

    }

    public void OnSpellTrigger(Spell spell) {
        Debug.Log("Spell triggered: " + spell.Name);

        ActionManager.SpellTriggered();

        casting = true;
        this.activeSpell = spell;
    }

    public void OnActionTrigger(ActionType actionType) {
        Debug.Log("Action triggered: " + actionType.ToString());

        SpellManager.ActionTriggered();
        
        // Activate Action selection
        this.actionType = actionType;
        makingAction = true;

        if (actionType == ActionType.WAIT || actionType == ActionType.BLOCK) {
            // Those two actions do not need target
            GameAction.makeAction(this, actionType, ActiveCard, null);
        }
    }

    override public void OnCardSelected(Card targetCard) {
        Debug.Log("Target card selected: " + targetCard);

        if (makingAction)
        {
            GameAction.makeAction(this, actionType, ActiveCard, targetCard);
            return;
            
        }

        if (casting) {
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
            // TODO move this finished turn deeper to spell casting with some delay
            FinishedTurn();
            return;
        }
    }

    private void FinishedTurn() {
        InterruptInteraction();
    }

    private void InterruptInteraction() {

        ActionManager.FinishedTurn();
        SpellManager.FinishedTurn();

        casting = false;
        makingAction = false;
    }

    public bool AmITarget(Card card)
    {
        if (casting) {
            if (this == card.owner && activeSpell.TargetTeam == Target.TargetTeam.FRIEND) {
                return true;
            }

            if (this == card.enemy && activeSpell.TargetTeam == Target.TargetTeam.ENEMY)
            {
                return true;
            }

            return false;
        }

        if (makingAction)
        {
            if (this == card.owner)
                return false;

            // Only action I can be making is Attack, if I am not owner I am targeting an enemy.

            return true;
        }

        return false;
    }

    public bool IsInteracting()
    {
        return casting || makingAction;
    }

    public override void OnActionDone()
    {
        base.OnActionDone();

        FinishedTurn();
    }
}
