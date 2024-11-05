using UnityEngine.EventSystems;

public class ParcelBaseState : IState
{
    protected ParcelStateMachine stateMachine;

    public ParcelBaseState(ParcelStateMachine stateMachine)
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