using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour {

    public void Pause()
    {
        //GameManager.Paused = true;
        Time.timeScale = 0f;
    }

    public void UnPause() {
        //GameManager.Paused = false;
        Time.timeScale = 1f;
    }




}
