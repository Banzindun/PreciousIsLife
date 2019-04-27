using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Tooltip("Index of the level to transition to.")]
    public int LevelIndex;

    [Tooltip("Event that happens ")]
    public UnityEvent OnClickEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered ");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited ");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Mouse clicked.");
        OnClickEvent.Invoke();
    }
}
