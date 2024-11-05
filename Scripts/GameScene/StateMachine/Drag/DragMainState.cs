using UnityEngine.EventSystems;

public class DragMainState : DragBaseState
{
    public DragMainState(DragStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateMachine.drag.DefaultPivot();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.drag.IsOnSub)
        {
            stateMachine.ChangeState(stateMachine.main2SubState);
        }       
    }

    public override void Exit()
    {
        base.Exit();
    }
}