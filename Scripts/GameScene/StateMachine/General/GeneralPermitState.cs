using UnityEngine.EventSystems;

public class GeneralPermitState : GeneralBaseState
{
    public GeneralPermitState(GeneralStateMachine stateMachine) : base(stateMachine)
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
        if (UtilUI.IsPointerOverSpecificUI(GameSceneManager.Instance.dropZone.returnZone, eventData))
        {
            GameSceneManager.Instance.dropZone.DropToCustomer(base.stateMachine.document.gameObject);
        }
    }
}