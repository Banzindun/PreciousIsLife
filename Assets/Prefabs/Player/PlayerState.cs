using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerState {
    
    // Cards the player has at start of the level and then rewritten at the end
    public static List<CardDefinitionHolder> cardHolders = new List<CardDefinitionHolder>();

    // Player health.
    public static int health = 100;

}
