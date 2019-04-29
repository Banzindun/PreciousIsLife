using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BoardPlayer {

    public float blockChance;

    public float thinkingPeriod;

    private float timer;

    private bool thinking = false;

    public override void Play(Card activeCard)
    {
        base.Play(activeCard);

        thinking = true;
        timer = thinkingPeriod;
    }

    private void Update()
    {
        if (thinking)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                DoThinking();
            }
        }
    }

    private void DoThinking() {
        Card killableCard = canKill();
        if (killableCard != null)
        {
            // There is a card I can kill
            GameAction.makeAction(this, ActionType.TYPE.WAIT, ActiveCard, killableCard);
            return;
        }

        if (canBlock())
        {
            GameAction.makeAction(this, ActionType.TYPE.BLOCK, ActiveCard, null);
            return;
        }

        // Else select something to attack, even if nothing suits us
        Card targetCard = FindTarget();
        GameAction.makeAction(this, ActionType.TYPE.ATTACK, ActiveCard, targetCard);

        thinking = false;
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

        card.animator.enabled = true;
        card.animator.SetTrigger("OnDeath");
    }
}
