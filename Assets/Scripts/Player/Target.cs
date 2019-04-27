using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Target {

    public enum TargetType
    {
        ALL,
        SINGLE
    };

    public TargetType Type;

    // Target can be enemy
    // Target can be multiple enemies
    // Should have TargetType stored


}
