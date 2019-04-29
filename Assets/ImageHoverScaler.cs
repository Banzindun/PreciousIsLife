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

    public bool interactionEnabled = true;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (interactionEnabled)
        {
            sizingTo = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (interactionEnabled)
        {
            sizingTo = false;
        }
    }

    public void ManualPointerEnter()
    {
        sizingTo = true;
    }

    public void ManualPointerExit()
    {
        sizingTo = false;
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
