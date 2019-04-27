using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/Settings", order = 1)]
public class GameSetting : ScriptableObject {

    [Tooltip("List of all levels.")]
    public Level[] AllLevels;

    [Tooltip("Number of the current level.")]
    public int CurrentLevel;

    [SerializeField]
    [Range(0,1)]
    public float MusicVol;

    [SerializeField]
    [Range(0,1)]
    public float FxVol;
}
