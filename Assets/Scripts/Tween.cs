using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tween : MonoBehaviour
{
    [Tooltip("How long should the tweaning last:")]
    public float duration = 2;

    [Tooltip("Event to be invoked after the tweening is done.")]
    public UnityEvent EndEvent;

    public delegate void TweenDelegate(Vector3 num);
    public TweenDelegate tweenDelegate;

    // Start vector
    public Vector3 StartVector;

    // End vector
    public Vector3 EndVector;
    
    // Count duration, then end
    private float timer;

    public AnimationCurve curve;

    public enum Tweens
    {
        LINEAR,
        EASE_IN,
        CURVE
    }

    public Tweens tweenType;

    public void Initialize(TweenOptions o)
    {
        duration = o.duration;
        EndEvent = o.EndEvent;
        StartVector = o.StartVector;
        EndVector = o.EndVector;
        curve = o.curve;
        tweenType = o.tweenType;
        timer = 0;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float myDelta = timer / duration;

        // Check for end
        if (timer > duration) {
            myDelta = 1f;
        }

        Vector3 tweenedVector = TweenVector(StartVector, EndVector, myDelta);
        tweenDelegate.Invoke(tweenedVector);
        
        if (timer > duration) {
            // End the tweening by disenabling the script
            enabled = false;

            EndEvent.Invoke();
        }
    }



    private Vector3 TweenVector(Vector3 start, Vector3 end, float delta)
    {
        return new Vector3(
            TweenValue(start.x, end.x, delta),
            TweenValue(start.y, end.y, delta),
            TweenValue(start.z, end.z, delta));
    }

    private float TweenValue(float start, float end, float delta)
    {
        float value;

        switch (tweenType)
        {
            case Tweens.LINEAR:
                value = Linear(start, end, delta);
                break;

            case Tweens.EASE_IN:
                value = EaseIn(start, end, delta);
                break;

            case Tweens.CURVE:
                value = Curve(start, end, delta);
                break;

            default:
                value = 0;
                break;
        }

        return value;
    }

    float Linear(float start, float end, float delta)
    {
        return Mathf.Lerp(start, end, delta);
    }

    float EaseIn(float start, float end, float delta)
    {
        return Mathf.Lerp(start, end, delta * delta);
    }

    float Curve(float start, float end, float delta)
    {
        return (end - start) * curve.Evaluate(delta) + start;
    }
}
