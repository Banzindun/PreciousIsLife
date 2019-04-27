using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public CardDefinition definition;

    public string name;
    public CardTypes.Type type;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;

    public bool alive;
    


    public void SetType (CardTypes.Type newType)
    {
        type = newType;
    }
    public void SetHP (int value)
    {
        hP = value;
    }
    public void SetLevel (int value)
    {
        level = value;
    }
    public void SetAttackValue (int value)
    {
        attackValue = value;
    }
    public void SetInitiative (int value)
    {
        initiative = value;
    }
    public void SetAliveStatus(bool newStatus)
    {
        alive = newStatus;
    }
    public void SetImage(Text imageName)
    {

    }

    // Action methods
    public static void Summon(CardDefinition def)
    {
        Card cardTemplate = def.template;
        Instantiate(cardTemplate, new Vector3(0, 0, 0), Quaternion.identity);

        cardTemplate.setCardDefinition(def);
        cardTemplate.SetAliveStatus(true);
    }

    private void setCardDefinition(CardDefinition def)
    {
        name = def.name;
        type = def.type;
        hP = def.hP;
        level = def.level;
        attackValue = def.attackValue;
        initiative = def.initiative;
    }

    public void Heal (int value)
    {

    }
    public void Damage (int value)
    {

    }
    public void LevelUp()
    {

    }
    public void Revival()
    {

    }
    public void Death()
    {

    }


    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {

       

}
}
