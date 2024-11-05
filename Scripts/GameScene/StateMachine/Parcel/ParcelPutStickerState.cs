using UnityEngine.EventSystems;

public class ParcelPutStickerState : ParcelBaseState
{
    public ParcelPutStickerState(ParcelStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (GameSceneManager.Instance.isStamp && UtilUI.IsPointerOverSpecificUI(GameSceneManager.Instance.dropZone.collectZone, eventData))
        {
            stateMachine.document.Collect();
        }
    }
}