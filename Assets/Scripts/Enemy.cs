using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BoardPlayer {

    public float blockChance;

    public override void Play(Card activeCard)
    {
        base.Play(activeCard);

        Card killableCard = canKill();
        if (killableCard != null) {
            // There is a card I can kill
            GameAction.makeAction(this, ActionType.TYPE.WAIT, activeCard, killableCard);
            return;
        }

        if (canBlock())
        {
            GameAction.makeAction(this, ActionType.TYPE.BLOCK, activeCard, null);
            return;
        }

        // Else select something to attack, even if nothing suits us
        Card targetCard = FindTarget();
        GameAction.makeAction(this, ActionType.TYPE.ATTACK, activeCard, targetCard);
    }

    private Card FindTarget()
    {
        Card bestTarget = null;

        double bestDamage = float.MinValue;

        foreach (Card c in Enemy.Cards) {
            double damage = c.GetDamage(ActiveCard);
            if (damage > bestDamage) {
                bestTarget = c;
                bestDamage = damage;
            }
        }

        return bestTarget;
    }

    
    private bool canBlock()
    {
        double rnd = UnityEngine.Random.Range(0f, 1f);
        if (rnd < blockChance)
            return true;

        return false;
    }

    private Card canKill()
    {
        foreach (Card c in Enemy.Cards) {
            if (ActiveCard.CanKill(c))
                return c;
        }

        return null;
    }

    override public void RemoveCard(Card card)
    {
        // I do not remove cards for the player
        base.RemoveCard(card);

        // TODO add some delay here
        Destroy(card.gameObject);
    }
}
