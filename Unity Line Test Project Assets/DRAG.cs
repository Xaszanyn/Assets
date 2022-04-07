using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DRAG : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OPD");
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OBD");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("DRAG");
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("END");
    }
}
