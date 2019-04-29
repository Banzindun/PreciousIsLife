using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Tooltip("Index of the level to transition to.")]
    public int LevelIndex;

    [Tooltip("Event that happens ")]
    public UnityEvent OnClickEvent;

    public bool interactionEnabled = true;

    
    private void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (interactionEnabled) {
            // Scale up or light it up
            GetComponent<ImageHoverScaler>().ManualPointerEnter();
        }
    }

    internal void Disable()
    {
        interactionEnabled = false;

        Image image = GetComponent<Image>();

        Color imageColor = image.color;
        imageColor.a = 0.5f;
        image.color = imageColor;
        // TODO More effects here

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (interactionEnabled)
        {
            GetComponent<ImageHoverScaler>().ManualPointerExit();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactionEnabled)
        {
            OnClickEvent.Invoke();
        }
    }
}
