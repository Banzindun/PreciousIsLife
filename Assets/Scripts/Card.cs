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
    public Text nameLabel;
    public Text hPLabel;
    public string name;
    public CardTypes.Type type;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public bool alive;
    public bool gamerTeam;
    public GameObject mainImageGO;
    public GameObject typeImageGO;
    public Sprite backgroundImage;
    public Sprite mainImage;
    public Sprite typeImage;
    public BoardPlayer owner;

    // Update is called once per frame
    void Update()
    {

    }

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
        backgroundImage = cardDefinition.backgroundImage;
        mainImage = cardDefinition.mainImage;
        typeImage = cardDefinition.typeImage;

        nameLabel.text = name;
        hPLabel.text = hP.ToString();
    }

    /* Set the map parameters and place it on the stage */
    public static GameObject Summon (BoardPlayer owner, CardDefinition cardDefinition)
    {
        Card cardTemplate = cardDefinition.template;
        cardTemplate.gameObject.name = cardDefinition.name;

        Card card = Instantiate(cardTemplate);
        
        card.setCardDefinition(cardDefinition);
        card.owner = owner;
        card.alive = true;

        Image backgroundCardImage = cardTemplate.GetComponent<Image>();
        backgroundCardImage.sprite = card.backgroundImage;

        Image frontCardImage = card.mainImageGO.GetComponent<Image>();
        frontCardImage.sprite = card.mainImage;

        Image typeCardImage = card.typeImageGO.GetComponent<Image>();
        typeCardImage.sprite = card.typeImage;

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

    public CardDefinition GetCardDefinitionSignature()
    {
        return CardDefinition.Create(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        nameLabel.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        nameLabel.gameObject.SetActive(false);
    }
}