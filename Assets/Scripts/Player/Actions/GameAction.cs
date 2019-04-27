using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameAction {
    public static void makeAction(GameManager manager, ActionType actionType, Card actorCard, Card targetCard) {
        switch (actionType) {
            case ActionType.ATTACK:
                Attack(actorCard, targetCard);
                break;

            case ActionType.BLOCK:
                Block(actorCard, targetCard);
                break;

            case ActionType.WAIT:
                Wait();
                break;
        }

        // Add some delay to invocation here.
        manager.ActionDone();
    }

    private static void Wait()
    {
        throw new NotImplementedException();
    }

    private static void Block(Card actorCard, Card targetCard)
    {
        throw new NotImplementedException();
    }

    private static void Attack(Card actorCard, Card targetCard)
    {
        throw new NotImplementedException();
    }
}
