using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FSMDragController : MonoBehaviour, IBeginDragHandler,
    IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    StateMachine docsStateMachine;

    private void Start()
    {
        if(TryGetComponent<Document>(out var document))
        {
            docsStateMachine = document.stateMachine;
        }
        else Debug.Assert(false, $"{gameObject.name} TryGetComponent<Document>½ÇÆÐ");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        docsStateMachine.currentState.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        docsStateMachine.currentState.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        docsStateMachine.currentState.OnEndDrag(eventData);       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        docsStateMachine.currentState.OnPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        docsStateMachine.currentState.OnPointerUp(eventData);
    }
}
