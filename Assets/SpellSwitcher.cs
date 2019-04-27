using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSwitcher : MonoBehaviour {

    public GameObject healSpells;

    public GameObject healIcon;

    public GameObject damageSpells;

    public GameObject damageIcon;

    private bool damageActive = true;

    public void Switch() {
        if (damageActive)
        {
            healSpells.SetActive(false);
            healIcon.SetActive(false);
            damageSpells.SetActive(true);
            damageIcon.SetActive(true);
        }
        else {
            healSpells.SetActive(true);
            healIcon.SetActive(true);
            damageSpells.SetActive(false);
            damageIcon.SetActive(false);
        }

        damageActive = !damageActive;
    }
}
