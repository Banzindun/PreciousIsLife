using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

    public PlayerController player;

    public ActionActivator[] actionActivators;

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

    private void DisableActions()
    {
        foreach (ActionActivator aa in actionActivators)
        {
            aa.Deactivate();
        }
    }

    private void EnableActions()
    {
        foreach (ActionActivator aa in actionActivators)
        {
            aa.Activate();
        }
    }

}
