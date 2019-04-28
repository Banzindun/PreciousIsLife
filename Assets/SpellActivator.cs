using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellActivator : MonoBehaviour {

    public Spell Spell;

    public SpellManager spellManager;

    private Button button;

    private ImageHoverScaler ihs;

    public void ActivateSpell() {
        spellManager.ActivateSpell(this, Spell);
    }

    internal void Deactivate()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        
        // TODO: This won't work if this is the one I have clicked on
        
        ihs = GetComponentInChildren<ImageHoverScaler>();
        ihs.enabled = false;
    }

    internal void Activate()
    {
        button = GetComponent<Button>();
        button.interactable = true;
        ihs.enabled = false;
    }
}
