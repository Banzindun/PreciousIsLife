using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    /* Card options */
    public CardDefinition cardDefinition;
    public string name;
    public CardTypes.Type type;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public bool alive;
    public bool gamerTeam;
    public static GameObject imageObject;
    public static Sprite pic1;
    public static Sprite pic2;

    public BoardPlayer owner;

    /* Set the starting parameters according to the card class definition */
    private void setCardDefinition(CardDefinition cardDefinition)
    {
        this.cardDefinition = cardDefinition;
        
        name = cardDefinition.name;
        type = cardDefinition.type;
        hP = cardDefinition.hP;
        level = cardDefinition.level;
        attackValue = cardDefinition.attackValue;
        initiative = cardDefinition.initiative;
        gamerTeam = cardDefinition.gamerTeam;
        imageObject = cardDefinition.imageObject;
        pic1 = cardDefinition.pic1;
        pic2 = cardDefinition.pic2;
    }

    /* Set the map parameters and place it on the stage */
    public static GameObject Summon(BoardPlayer owner, CardDefinition cardDefinition)
    {
        Card cardTemplate = cardDefinition.template;
        cardTemplate.gameObject.name = cardDefinition.name;

        Card card = Instantiate(cardTemplate);
        
        card.setCardDefinition(cardDefinition);
        card.owner = owner;
        card.alive = true;

        Image backgroundCardImage = cardTemplate.GetComponent<Image>();
        backgroundCardImage.sprite = pic1;

        Image frontCardImage = imageObject.GetComponent<Image>();
        frontCardImage.sprite = pic2;

        return card.gameObject;
    }

    /* Methods for changing the parameters of the card during the game */
    public void Heal (int value)
    {
        hP = hP + value;
    }
    public void Damage (int value)
    {
        hP = hP - value;
    }
    public void LevelUp()
    {
        level++;
    }
    public void Revival()
    {
        alive = true;
    }
    public void Death()
    {
        alive = false;

        // Tell the owner to remove the card
        owner.RemoveCard(this);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}