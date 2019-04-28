using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Target {

    public enum TargetTeam {
        ENEMY,
        FRIEND
    }

    public TargetTeam targetTeam;

    public enum TargetType
    {
        ALL,
        SINGLE
    };

    public TargetType targetType;

    List<Card> targetCards = new List<Card>();

    public void addTarget(Card card) {
        if (targetCards == null)
            targetCards = new List<Card>();

        targetCards.Add(card);
    }

    public List<Card> getTargets() {
        return targetCards;
    }
}
