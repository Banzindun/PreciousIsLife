using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionType : ScriptableObject {
    public enum TYPE
    {
        ATTACK,
        BLOCK,
        WAIT
    }

    public TYPE type;

    public Color effectColor;
    
}