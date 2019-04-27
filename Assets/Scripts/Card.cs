using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /* Card options */
    public CardDefinition cardDefinition;
    public Text n;
    public string name;
    public CardTypes.Type type;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public bool alive;
    public bool gamerTeam;
    public static GameObject mainImageGO;
    public static GameObject typeImageGO;
    public static Sprite backgroundImage;
    public static Sprite mainImage;
    public static Sprite typeImage;
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
        mainImageGO = cardDefinition.mainImageGO;
        typeImageGO = cardDefinition.typeImageGO;
        backgroundImage = cardDefinition.backgroundImage;
        mainImage = cardDefinition.mainImage;
        typeImage = cardDefinition.typeImage;
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
        backgroundCardImage.sprite = backgroundImage;

        Image frontCardImage = mainImageGO.GetComponent<Image>();
        frontCardImage.sprite = mainImage;

        Image typeCardImage = typeImageGO.GetComponent<Image>();
        typeCardImage.sprite = typeImage;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        n.gameObject.SetActive(true);
        Debug.Log("enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        n.gameObject.SetActive(false);
        Debug.Log("exit");
    }
}