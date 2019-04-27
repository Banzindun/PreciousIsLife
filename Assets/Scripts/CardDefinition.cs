using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardDefinition : ScriptableObject {
    public CardTypes.Type type;

    public string name;
    
    public int hP;
    public int level;
    public int attackValue;
    public int initiative;

    public Card template;


}
