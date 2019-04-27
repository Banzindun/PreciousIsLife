using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerState : ScriptableObject {
    [SerializeField]
    private CardDefinition[] myCards;

    public CardDefinition[] MyCards {
        set
        {
            myCards = value;
        }

        get
        {
            return myCards;

        }
    }


    private int health;

    public int Health {
        set
        {
            health = value;
        }

        get
        {
            return health;
        }
    }

}
