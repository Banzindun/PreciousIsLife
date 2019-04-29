using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeScaler : MonoBehaviour {

    [Tooltip("What is the desired scale.")]
    public float desiredScale;

    [Tooltip("How fast does it rotate.")]
    public float rotationRate;

    [Tooltip("How fast does it scale.")]
    public float scaleRate;

    private float startingScale;

    private float startingRotation;

    private float scaleDuration;

    private float rotationDuration;


    // Use this for initialization
    void Start () {
        startingScale = transform.localScale.x;

        scaleDuration = scaleRate;
        rotationDuration = rotationRate;


    }
	
	// Update is called once per frame
	void Update () {
        scaleDuration -= Time.deltaTime;
        rotationDuration -= Time.deltaTime;

        float lerpValue = Mathf.Lerp(desiredScale, startingScale, scaleDuration / scaleRate);
        transform.localScale = Vector3.one * lerpValue;

        if (scaleDuration <= 0)
        {
            scaleDuration = scaleRate;
        }
        
        // Will rotate only on z
        lerpValue = Mathf.Lerp(1, 0, rotationDuration / rotationRate);
        transform.rotation = Quaternion.Euler(0, 0, lerpValue*360);

        if (rotationDuration <= 0)
        {
            rotationDuration = rotationRate;
        }
    }
}
