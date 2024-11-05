using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubDocument : MonoBehaviour//, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject MainDesk;
    public Document MainDocument;

    //public Shadow shadow;
    //public Shadow mainObjectShadow;

    //private DragController dragController;

    private void Awake()
    {
        //shadow = GetComponentInChildren<Shadow>();
        //dragController = GetComponent<DragController>();
    }

    protected void Start()
    {
        MainDocument = UtilGeneric.FindChildByTag<Document>(MainDesk, this.gameObject);

        //mainObjectShadow = MainDocument.shadow;
    }

    //public virtual void OnPointerDown(PointerEventData eventData)
    //{
    //    dragController.OnPointerDown(eventData);
    //    dragController.mainDeskObjectImage.GetComponent<RectTransform>().SetAsLastSibling();
    //    mainObjectShadow.enabled = true;
    //}
    //public virtual void OnDrag(PointerEventData eventData)
    //{
    //    FindMousePlace.instance.MoveObjectToMousePosition(dragController.mainDeskObjectImage);

    //    dragController.mainDeskObjectImage.SetActive(!FindMousePlace.instance.inSubDesk);
    //    dragController.subDeskObjectImage.SetActive(FindMousePlace.instance.inSubDesk);
    //}

    //public virtual void OnPointerUp(PointerEventData eventData)
    //{
    //    dragController.OnPointerUp(eventData);
    //    mainObjectShadow.enabled = false;
    //}
}
