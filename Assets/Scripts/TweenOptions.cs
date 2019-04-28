using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TweenOptions {

    [Tooltip("How long should the tweaning last:")]
    public float duration = 2;

    [Tooltip("Event to be invoked after the tweening is done.")]
    public UnityEvent EndEvent;

    // Start vector
    public Vector3 StartVector;

    // End vector
    public Vector3 EndVector;

    public Tween.Tweens tweenType;

    public AnimationCurve curve;

}
