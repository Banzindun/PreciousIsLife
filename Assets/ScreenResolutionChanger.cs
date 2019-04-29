using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolutionChanger : MonoBehaviour {

    public Dropdown resolutionDropdown;

    public Toggle fullscreenToggle;


    public void OnBackButton() {

        int index = resolutionDropdown.value;
        bool fullscreen = fullscreenToggle.isOn;

        switch (index) {
            case 0:
                Screen.SetResolution(1920, 1080, fullscreen);
                break;

            case 1:
                Screen.SetResolution(1600, 900, fullscreen);
                break;

            case 2:
                Screen.SetResolution(1280, 720, fullscreen);
                break;

            default:
                break;
        }


    }

    private void Start()
    {
        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;

        if (width == 1920 && height == 1080) {
            resolutionDropdown.value = 0;
        } else if (width == 1600 && height == 900) {
            resolutionDropdown.value = 1;
        } else if (width == 1280 && height == 720) {
            resolutionDropdown.value = 2;
        }

        fullscreenToggle.isOn = Screen.fullScreen;
    }
}
