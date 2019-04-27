using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuDisabler : MonoBehaviour {

    public GamePauser gamePauser;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            DisableMenu();
        }
        

	}

    public void DisableMenu() {
        gameObject.SetActive(false);
        gamePauser.UnPause();
    }
}
