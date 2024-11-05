using UnityEngine.EventSystems;

public class DragMain2SubState : DragBaseState
{
    public DragMain2SubState(DragStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateMachine.drag.ResetPivot();
    }

    public override void Update()
    {
        base.Update();
        if (!stateMachine.drag.IsOnSub)
        {
            stateMachine.ChangeState(stateMachine.mainState);
        }        
    }

    public override void Exit()
    {
        base.Exit();
    }
}