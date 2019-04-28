using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameSetting GameSetting;

    public LevelSelector[] levelSelectors;

	// Use this for initialization
	void Start () {
        int index = GameSetting.CurrentLevelIndex;
        DisableLevelSelectors(index);

	}

    private void DisableLevelSelectors(int index)
    {
        foreach (LevelSelector ls in levelSelectors) {
            if (ls.LevelIndex != index)
                ls.Disable();
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
