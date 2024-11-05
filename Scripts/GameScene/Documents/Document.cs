using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Document : MonoBehaviour
{
    protected CustomerData customerData;
    //public GameObject SubDesk;
   // public SubDocument subDocument;
    public StateMachine stateMachine;

    protected virtual void Awake()
    {
        //shadow = GetComponentInChildren<Shadow>();
        //dragController = GetComponent<DragController>();        
    }

    protected virtual void Start()
    {
        //subDocument = UtilGeneric.FindChildByTag<SubDocument>(SubDesk, this.gameObject);

    //    subObjectShadow = subDocument.shadow;
    //    dragController.mainDeskObjectImage = shadow.gameObject;
    //    dragController.subDeskObjectImage = subObjectShadow.gameObject;

        GameSceneManager.Instance.eventSubject.OnUpdateUI += UpdateUI;
    }
    protected virtual void OnDestroy()
    {
        GameSceneManager.Instance.eventSubject.OnUpdateUI -= UpdateUI;
    }

    protected abstract void UpdateUI();

}

