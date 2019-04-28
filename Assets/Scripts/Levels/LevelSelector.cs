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

    // Use this for initialization
    void Start () {

	}

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    internal void Disable()
    {
        enabled = false;
        // TODO More effects here

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        OnClickEvent.Invoke();

    }
}
