using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CardDefinition : ScriptableObject
{
    // Start parameters
    public CardTypes.Type type;
    public string name;
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;
    public Card template;
    public bool gamerTeam;
    public  Sprite pic1;
    public  Sprite pic2;


    // Function called on each card after a new turn
    public void OnNewTurn() {

    }
}