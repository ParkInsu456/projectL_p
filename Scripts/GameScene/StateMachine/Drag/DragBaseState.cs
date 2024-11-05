using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragBaseState : IStateForDrag
{
    protected DragStateMachine stateMachine;

    public DragBaseState(DragStateMachine stateMachine)
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
}