using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFiller : MonoBehaviour {

    public Slider slider;

    private int lastHealth;

    public GameObject healthLostPrefab;

    public float healthLostEffectDuration;

    public Color healthLostColor;

    public Color healthGainedColor;

    public float healthLostEffectSpeed;

    public GameObject healEffectHolder;

    private void Start()
    {
        lastHealth = PlayerState.health;
    }

    // Update is called once per frame
    void Update () {
        int health = PlayerState.health;

        if (health > lastHealth)
        {
            SpawnHealthEffect(true, health-lastHealth);
        }
        else if (health < lastHealth) {
            SpawnHealthEffect(false, lastHealth - health);
        }

        slider.value = health/100f;
        lastHealth = health;
	}

    private void SpawnHealthEffect(bool positive, int value)
    {
        GameObject healthEffect = Instantiate(healthLostPrefab);
        healthEffect.transform.SetParent(healEffectHolder.transform);
        healthEffect.transform.localPosition = Vector3.zero;
        
        Text text = healthEffect.GetComponent<Text>();
        if (!positive) {
            text.text = "-" + value;
            text.color = healthLostColor;
        }
        else {
            text.text = value + "";
            text.color = healthGainedColor;
        }

        HealthEffect he = healthEffect.GetComponent<HealthEffect>();
        he.duration = healthLostEffectDuration;
        he.speed = healthLostEffectSpeed;
        
    }
}
