using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthEffect : MonoBehaviour {

    public float duration;

    public float speed;

    private float passed;

    private Text text;

	// Use this for initialization
	void Start () {
        passed = duration;
        text = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        passed -= Time.deltaTime;

        if (passed <= 0) {
            Destroy(gameObject);
        }

        Vector3 position = transform.localPosition;
        position.y = position.y + Time.deltaTime * speed;
        transform.localPosition = position;

        Color color = text.color;
        color.a = Mathf.Lerp(0, 1, passed/duration);
        text.color = color;

	}
}
