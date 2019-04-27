using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Highlights text when mouse enters it
public class TextHoverHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Text text;

    [Tooltip("Color of the text upon highlighting.")]
    [SerializeField]
    private Color color;

    private Color oldColor;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();

        if (text == null)
            text = GetComponentInChildren<Text>();

        oldColor = text.color;
	}

    private void OnDisable()
    {
        if (text != null)
            text.color = oldColor;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        oldColor = text.color;
        text.color = color;

        if (AudioManager.instance != null)
        {
            AudioManager.instance.Play("Click");
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        text.color = oldColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = oldColor; //Or however you do your color
    }
}
