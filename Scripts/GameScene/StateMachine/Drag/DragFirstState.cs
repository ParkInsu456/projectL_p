using UnityEngine.EventSystems;

public class DragFirstState : DragBaseState
{
    public DragFirstState(DragStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.drag.isChange)
        {
            if (stateMachine.drag.IsOnSub)
            {
                stateMachine.ChangeState(stateMachine.subState);
            }
            else if (!stateMachine.drag.IsOnSub)
            {
                stateMachine.ChangeState(stateMachine.mainState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}