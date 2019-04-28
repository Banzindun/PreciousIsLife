using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the ortographic size of camera to be half the height of the screen.
/// </summary>
public class CameraConfigurator : MonoBehaviour {

    [Tooltip("Reference to the camera.")]
    public Camera CameraReference;

	// Use this for the initialization
	void Update () {

        int cameraHeight = Screen.height;
        float desiredAspect = 16f / 9f;
        float aspect = Camera.main.aspect;
        float ratio = desiredAspect / aspect;
        Camera.main.orthographicSize = cameraHeight * ratio;

        //CameraReference.orthographicSize = Screen.height / 2f;
    }
	
}
