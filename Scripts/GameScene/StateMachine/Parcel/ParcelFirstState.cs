using UnityEngine.EventSystems;

public class ParcelFirstState : ParcelBaseState
{
    // 맨처음, 모두 false상태
    public ParcelFirstState(ParcelStateMachine bIStateMachine) : base(bIStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.Flags.IsStampRefuse)
        {
            stateMachine.ChangeState(stateMachine.refuseState);
        }
        else if (stateMachine.Flags.IsStampPermit)
        {
            stateMachine.ChangeState(stateMachine.permitState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (UtilUI.IsPointerOverSpecificUI(GameSceneManager.Instance.dropZone.returnZone, eventData))
        {
            GameSceneManager.Instance.dropZone.DropToDesk(base.stateMachine.document.gameObject);
        }
    }
}