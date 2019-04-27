using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    private GameSetting settings;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider fxSlider;

    // Use this for initialization
	void Start () {
        musicSlider.value = settings.MusicVol;
        fxSlider.value = settings.FxVol;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeMusicVolume(float value) {
        settings.MusicVol = value;
    }

    public void ChangeFXVolume(float value) {
        settings.FxVol = value;
    }

}
