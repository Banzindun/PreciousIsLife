using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerState : ScriptableObject {
    private Card[] myCards;

    public Card[] MyCards {
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
