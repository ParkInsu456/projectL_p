using System;

public class DragStateMachine : StateMachineForDrag
{
    public DraggableUIElement drag { get; }
    public DragFirstState firstState { get; }
    public DragSubState subState { get; }
    public DragSub2MainState sub2MainState { get; }
    public DragMainState mainState { get; }
    public DragMain2SubState main2SubState { get; }

    public DragStateMachine(DraggableUIElement drag)
    {
        this.drag = drag;
        
        firstState = new DragFirstState(this);
        subState = new DragSubState(this);
        sub2MainState = new DragSub2MainState(this);
        mainState = new DragMainState(this);
        main2SubState = new DragMain2SubState(this);
    }
}