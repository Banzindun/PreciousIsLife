using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionActivator : MonoBehaviour {

    public ActionType ActionType;

    public ActionManager actionManager;

    private Button button;

    public void ActivateAction()
    {
        actionManager.ActivateAction(this, ActionType);
    }

    internal void Deactivate()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    internal void Activate()
    {
        button = GetComponent<Button>();
        button.interactable = true;
    }
}
