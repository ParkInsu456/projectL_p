using UnityEngine.EventSystems;

public class BIPutStickerState : BIBaseState
{
    public BIPutStickerState(BIStateMachine stateMachine) : base(stateMachine)
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
    }
}