using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour {

    public PlayerController player;

    public ActionActivator[] actionActivators;

    public AttackBehaviourDefinition AttackBehaviourConstants;

    public GameObject continueButton;

    internal void ActivateAction(ActionActivator actionActivator, ActionType actionType)
    {
        // Activate action
        player.OnActionTrigger(actionType);

        // Disable the rest of the fields
    }

    internal void SpellTriggered()
    {
        DisableActions();
    }

    internal void FinishedTurn()
    {
        EnableActions();
    }

    public void DisableActions()
    {
        foreach (ActionActivator aa in actionActivators)
        {
            aa.Deactivate();
        }
    }

    public void EnableActions()
    {
        foreach (ActionActivator aa in actionActivators)
        {
            aa.Activate();
        }
    }

    internal void HideActions()
    {
        foreach (ActionActivator aa in actionActivators)
        {
            aa.gameObject.SetActive(false);
        }
    }

    internal void EnableContinue()
    {
        continueButton.SetActive(true);
        HideActions();       
    }
}
