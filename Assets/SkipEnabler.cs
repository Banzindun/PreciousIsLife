using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipEnabler : MonoBehaviour {

    public GameSetting gameSettings;

    public Button button;

    // Use this for initialization
    void Start () {
        if (gameSettings.CurrentLevelIndex == 0)
        {
            button.interactable = false;
        }
        else {
            button.interactable = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
