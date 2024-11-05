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
    // XX����, ������ ���¿� ���� ������������ �� �� �ִ����������� ������ State�� �������Ѵ�.

    // ���ӿ����� �ൿ������(�������, � ������ ��������, �����ڸ��� ����� Ŭ��������) ���ӿ� �����ϴ� �����鿡 �������������� bool�� ���� ��ȣ�� ������.
    // ������ ���Ӿ��Ŵ����� �ִ� State�� �����ϴ°ͺ��� �������� ���� State�� ������ �ϸ� ĸ��ȭ�� �� �����Ű���.

    // ���������� ������ ���� ���� bool���� �ٸ����¸� ������ �ִ�.

    // �������� ������� ��ü�� �����ԵǴµ�...
    // ���ʹ��� StateMachine, �÷��̾��� StateMachine�� �������� �ٸ��ൿ�� �ʿ��� ������ ���ο� StateMachine�� ������ �ȴ�.

    ////////
    //�� Ŭ������ �� State�� ������ �⺻���� �͵�
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
