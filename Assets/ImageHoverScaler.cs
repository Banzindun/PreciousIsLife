using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageHoverScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField]
    private float toScale = 2f;

    [SerializeField]
    private float fromScale = 1f;

    private bool sizingTo = false;

    [SerializeField]
    private float ChangeSpeed = 5f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        sizingTo = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sizingTo = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float wantedScale;

        if (sizingTo)
        {
            wantedScale = toScale;
        }
        else {
            wantedScale = fromScale;
        }

        Vector3 scale = transform.localScale;
        transform.localScale = Vector3.Lerp(scale, new Vector3(wantedScale, wantedScale, wantedScale), Time.deltaTime*ChangeSpeed);
	}
}
