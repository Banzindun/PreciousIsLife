using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResetter : MonoBehaviour {

    private void Start()
    {
        PlayerState.cardHolders = new List<CardDefinitionHolder>();
        PlayerState.health = 100;
    }


}
