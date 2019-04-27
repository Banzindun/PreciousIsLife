using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the ortographic size of camera to be half the height of the screen.
/// </summary>
public class CameraConfigurator : MonoBehaviour {

    [Tooltip("Reference to the camera.")]
    public Camera CameraReference;

	// Use this for initialization
	void Start () {
        CameraReference.orthographicSize = Screen.height / 2f;
	}
	
}
