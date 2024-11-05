using UnityEngine.EventSystems;

public class DragSub2MainState : DragBaseState
{
    public DragSub2MainState(DragStateMachine stateMachine) : base(stateMachine)
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
        if (stateMachine.drag.IsOnSub)
        {
            stateMachine.ChangeState(stateMachine.subState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}