using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;

    private string levelToLoad;
	
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FadeToLevel(string name) {
        animator.SetTrigger("FadeOut");
        levelToLoad = name;
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
