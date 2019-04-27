using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    /* Card options */
    //public CardDefinition definition;
    public string name;
    public CardTypes.Type type;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public bool alive;
    public bool gamerTeam;
    public GameObject imageObject;
    public Sprite pic1;
    public Sprite pic2;

    /* Set the starting parameters according to the card class definition */
    private void setCardDefinition(CardDefinition cardDefinition)
    {
        name = cardDefinition.name;
        type = cardDefinition.type;
        hP = cardDefinition.hP;
        level = cardDefinition.level;
        attackValue = cardDefinition.attackValue;
        initiative = cardDefinition.initiative;
        gamerTeam = cardDefinition.gamerTeam;
        pic1 = cardDefinition.pic1;
        pic2 = cardDefinition.pic2;
    }

    /* Set the map parameters and place it on the stage */
    public void Summon(CardDefinition cardDefinition)
    {
        Card cardTemplate = cardDefinition.template;
        Instantiate(cardTemplate, new Vector3(0, 0, 0), Quaternion.identity);

        cardTemplate.setCardDefinition(cardDefinition);
        cardTemplate.alive = true;

        Image backgroundCardImage = cardTemplate.GetComponent<Image>();
        backgroundCardImage.sprite = pic1;

        Image frontCardImage = imageObject.GetComponent<Image>();
        frontCardImage.sprite = pic2;
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
    }

    // Update is called once per frame
    void Update ()
    {

    }
}