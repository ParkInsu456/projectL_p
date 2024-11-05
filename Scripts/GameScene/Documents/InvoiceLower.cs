using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvoiceLower : Document, IDragHandler
{
    public new GeneralStateMachine stateMachine;
    public bool isCut;

    protected override void UpdateUI()
    {
    }

    private new void Start()
    {
        stateMachine = new GeneralStateMachine(this);
        base.stateMachine = stateMachine;
        stateMachine.ChangeState(stateMachine.firstState);
        GameSceneManager.Instance.eventSubject.OnCut += AddEvent;
    }
    public void ResetState()
    {
        stateMachine.Flags.FalseAll();
        stateMachine.ChangeState(stateMachine.firstState);
    }
    void Update()
    {
        stateMachine.Update();

            
    }

    public void AddEvent()
    {
        isCut = true;
    }
    public void ResetEvent()
    {
        isCut = false;
    }

    public void SetActiveStamps()
    {
        if (GameSceneManager.Instance.stampA.stamps.Count != 0)
        {
            foreach (var item in GameSceneManager.Instance.stampA.stamps)
            {
                item.gameObject.SetActive(!GameSceneManager.Instance.mouse.IsOnSub);
            }
        }
        if (GameSceneManager.Instance.stampB.stamps.Count != 0)
        {
            foreach (var item in GameSceneManager.Instance.stampB.stamps)
            {
                item.gameObject.SetActive(!GameSceneManager.Instance.mouse.IsOnSub);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCut)
        {
            SetActiveStamps();
        }
    }
}
