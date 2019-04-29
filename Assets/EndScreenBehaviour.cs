using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenBehaviour : MonoBehaviour {

    public Sprite BlurredBackground;

    public Image backgroundImage;

    public GameObject firstScreenStuff;
    public GameObject secondScreenStuff;


    public void EnableSecondScreen() {
        backgroundImage.sprite = BlurredBackground;
        firstScreenStuff.SetActive(false);
        secondScreenStuff.SetActive(true);
    }
}
