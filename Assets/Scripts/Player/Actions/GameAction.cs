using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameAction {
    public static void makeAction(BoardPlayer player, ActionType actionType, Card actorCard, Card targetCard) {
        player.GameManager.DisablePlayerInteractions();

        switch (actionType) {
            case ActionType.ATTACK:
                Attack(player, actorCard, targetCard);
                break;

            case ActionType.BLOCK:
                Block(player, actorCard);
                break;

            case ActionType.WAIT:
                Wait(player, actorCard);
                break;
        }

        // Actions should themselves call the player.OnActionDone()
        
    }

    private static void Wait(BoardPlayer player, Card actorCard)
    {
        player.GameManager.AddCardToInitiationQueue(actorCard);

        // TODO add delay and WaitBehaviour
        player.OnActionDone();
    }

    private static void Block(BoardPlayer player, Card actorCard)
    {
        actorCard.hasShield = true;
        actorCard.HighlightShield();

        // TODO add delay and BlockBehaviour
        player.OnActionDone();
    }

    private static bool Attack(BoardPlayer player, Card actorCard, Card targetCard)
    {
        // I cannot attack on my own minions
        if (targetCard.owner == actorCard.owner) {
            return false;
        }
        
        AttackBehaviour ab = actorCard.gameObject.AddComponent<AttackBehaviour>();
        ab.TargetCard = targetCard;
        ab.ActorCard = actorCard;
        ab.Player = player;
        ab.MovingCardCanvas = player.GameManager.MovingCardCanvas;
        ab.Initialize(player.GameManager.ActionManager.AttackBehaviourConstants);


        return true;
    }
}
