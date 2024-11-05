using UnityEngine.EventSystems;

public class DragSubState : DragBaseState
{
    public DragSubState(DragStateMachine stateMachine) : base(stateMachine)
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
        if (!stateMachine.drag.IsOnSub)
        {
            stateMachine.ChangeState(stateMachine.sub2MainState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}