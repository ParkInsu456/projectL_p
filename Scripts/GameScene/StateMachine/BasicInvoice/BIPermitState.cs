﻿using UnityEngine.EventSystems;

public class BIPermitState : BIBaseState
{
    public BIPermitState(BIStateMachine bIStateMachine) : base(bIStateMachine)
    {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.Flags.IsCut)
        {
            stateMachine.ChangeState(stateMachine.cutState);
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