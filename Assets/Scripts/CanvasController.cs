using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed.");
            ActivatePauseMenu();
        }
	}

    private void ActivatePauseMenu() {
        if (pauseMenu != null) {
            pauseMenu.SetActive(true);        }
    }
}
