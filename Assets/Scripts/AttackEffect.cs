using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackEffect : MonoBehaviour {

    public Image mainImage;

    public Color originalColor;

    public Color effectColor;

    public float duration;

    private float scheduled;

    // Use this for initialization
    void Start () {
        originalColor = mainImage.color;
        scheduled = duration;

	}
	
	// Update is called once per frame
	void Update () {
        scheduled -= Time.deltaTime;

        if (scheduled < 0)
        {
            OnDone();
        }
        else {
            mainImage.color = Color.Lerp(originalColor, effectColor, scheduled/duration);
        }        
	}

    private void OnDone() {
        // To be sure
        mainImage.color = originalColor;

        // Remove the effect
        Destroy(this);
    }
}
