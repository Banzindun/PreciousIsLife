using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFiller : MonoBehaviour {

    public Slider slider;
	
	// Update is called once per frame
	void Update () {
        slider.value = PlayerState.health/100f;
	}
}
