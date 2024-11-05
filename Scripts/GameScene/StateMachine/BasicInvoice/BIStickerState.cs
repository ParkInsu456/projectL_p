using UnityEngine.EventSystems;

public class BIStickerState : BIBaseState
{
    public BIStickerState(BIStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.Flags.IsPutSticker)
        {
            stateMachine.ChangeState(stateMachine.putStickerState);
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
        else if (UtilUI.IsPointerOverSpecificUI(GameSceneManager.Instance.parcel.imageObj, eventData))
        {
            base.stateMachine.document.AttachSticker();
        }
    }
}
