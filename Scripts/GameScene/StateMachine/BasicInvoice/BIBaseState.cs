using UnityEngine;
using UnityEngine.EventSystems;

public class BIBaseState : IState
{ 
    protected BIStateMachine stateMachine;
    
    public BIBaseState(BIStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {

    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        //if (!stateMachine.Flags.IsCut)
        //{
        //    GameSceneManager.Instance.eventSubject.EventStampImage();
        //    //stateMachine.document.SetActiveStamps(!stateMachine.document.drag.IsOnSub);
        //}
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
    }    
}