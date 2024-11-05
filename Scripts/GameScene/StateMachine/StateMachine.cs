using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IState : IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public void Enter();
    public void Update();
    public void Exit();
}

public interface IStateForDrag
{
    public void Enter();
    public void Update();
    public void Exit();
}

public abstract class StateMachine
{
    // XX했음, 안했음 상태에 따라 서류움직임을 할 수 있는지없는지를 가지는 State를 가지게한다.

    // 게임에서의 행동에따라(도장찍기, 어떤 도장이 찍혔는지, 송장자르기 등등의 클래스에서) 게임에 존재하는 서류들에 옵저버패턴으로 bool값 변경 신호를 보낸다.
    // 서류가 게임씬매니저에 있는 State를 참조하는것보다 서류마다 각자 State를 가지게 하면 캡슐화에 더 좋을거같다.

    // 상태진입의 순서에 따라서 같은 bool값도 다른상태를 가질수 있다.

    // 서류마다 현재상태 객체를 가지게되는데...
    // 에너미의 StateMachine, 플레이어의 StateMachine을 가지듯이 다른행동이 필요한 서류는 새로운 StateMachine을 가지면 된다.

    ////////
    //이 클래스는 각 State가 가지는 기본적인 것들
    ////////

    public IState currentState;

    public void ChangeState(IState state)
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
