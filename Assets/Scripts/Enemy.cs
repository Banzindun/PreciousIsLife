using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BoardPlayer {


    public override void Play(Card activeCard)
    {
        base.Play(activeCard);

        // TODO
    }

    override public void RemoveCard(Card card)
    {
        // I do not remove cards for the player
        base.RemoveCard(card);

        // TODO add some delay here
        Destroy(card.gameObject);

    }

}
