using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level.asset", menuName = "Game/Level")]
public class Level : ScriptableObject {

    public CardDefinition[] cardsToBeSpawned;

}
