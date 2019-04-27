using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SetVolume : MonoBehaviour {

    public AudioMixer mixer;

    [SerializeField]
    private string volumeParamName;

    public void SetLevel(float value) {
        mixer.SetFloat(volumeParamName, ConvertToDecibel(value));
    }

    public float ConvertToDecibel(float value)
    {
        return Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;
    }

    public void SetLevel(string name, float value) {
        mixer.SetFloat(name, value);
    }
}
