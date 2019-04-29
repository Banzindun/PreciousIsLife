using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardTypes : ScriptableObject
{
    public enum TYPE {
        MELEE, 
        RANGED,
        FLYING
    };

    public TYPE type;

    public Sprite backgroundImage;

    public Sprite backgroundImageNoStats;

    public Sprite typeImage;
}
