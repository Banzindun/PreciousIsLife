using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeTestSpace : MonoBehaviour {

    public GameObject FirstText;

    public GameObject SecondText;

    private bool allEnabled = false;

    public UnityEvent OnAllEnabled;

    public bool EnableTexts = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {

            
            if (!EnableTexts || allEnabled) {
                // Go to other scene
                OnAllEnabled.Invoke();
            }

            FirstText.SetActive(false);
            SecondText.SetActive(true);
            allEnabled = true;
        }
	}
}
