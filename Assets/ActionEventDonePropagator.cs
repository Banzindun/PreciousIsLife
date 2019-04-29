using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEventDonePropagator : MonoBehaviour {

    public Card card;

    public void PropagateOnActionEffectDone() {
        card.OnActionEffectDone();
    }
}
