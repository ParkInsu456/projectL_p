public abstract class StateMachineForDrag
{
    public IStateForDrag currentState;

    public void ChangeState(IStateForDrag state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }
    public void Update()
    {
        currentState?.Update();
    }
}