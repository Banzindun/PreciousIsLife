using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameAction {
    public static void makeAction(BoardPlayer player, ActionType.TYPE actionType, Card actorCard, Card targetCard) {
        player.GameManager.DisablePlayerInteractions();

        switch (actionType) {
            case ActionType.TYPE.ATTACK:
                Attack(player, actorCard, targetCard);
                break;

            case ActionType.TYPE.BLOCK:
                Block(player, actorCard);
                break;

            case ActionType.TYPE.WAIT:
                Wait(player, actorCard);
                break;
        }

        // Actions should themselves call the player.OnActionDone()
        
    }

    private static void Wait(BoardPlayer player, Card actorCard)
    {
        player.GameManager.AddCardToInitiationQueue(actorCard);

        actorCard.WaitUp();
    }

    private static void Block(BoardPlayer player, Card actorCard)
    {
        actorCard.hasShield = true;

        actorCard.ShieldUp();
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
