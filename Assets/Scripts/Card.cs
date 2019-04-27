using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{      
    public CardNames.Name name;
    public CardTypes.Type type;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public bool alive;
    public Card template;

    //Methods for setting values of parameters card
    public void SetName (CardNames.Name newName)
    {
        name = newName;
    }
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
    public void Summon(CardNames.Name name, CardTypes.Type type, int hP, int level, int attackValue, int initiative)
    {
        Instantiate(template, new Vector3(0, 0, 0), Quaternion.identity);

        switch (name)
        {
            case CardNames.Name.Gul:
                template.gameObject.name = "Gul";
                break;
            case CardNames.Name.SkeletonArcher:
                template.gameObject.name = "Akeleton Archer";
                break;
            case CardNames.Name.Dragon:
                template.gameObject.name = "Dragon";
                break;
        }

        template.SetName(name);
        template.SetType(type);
        template.SetHP(hP);
        template.SetLevel(level);
        template.SetAttackValue(attackValue);
        template.SetInitiative(initiative);
        template.SetAliveStatus(true);
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
