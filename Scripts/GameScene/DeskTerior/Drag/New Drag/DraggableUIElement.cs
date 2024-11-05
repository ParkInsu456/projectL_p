using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// TestDragScript, MainObjectEvent, SubObjectEvent의 역할
/// 에디터에서 각 서류오브젝트에 캐싱
/// </summary>
public class DraggableUIElement : MonoBehaviour, IPointerUpHandler, IBeginDragHandler, IDragHandler, IPointerDownHandler
{
    public MousePositionController mouse;    
    private RectTransform rectTransform;
    public GameObject main;
    public GameObject sub;
    public Shadow mainShadow;
    public Shadow subShadow;

    public DragStateMachine stateMachine;
    private bool prevIsOnSub;
    public bool isChange = false;
    public bool isMove = false;
    public bool isClickSubDesk;
    public bool IsOnSub
    {
        get { return mouse.IsOnSub; }
        set
        {            
            if (prevIsOnSub != value)
            {
                UpdateIsOnSub(value);
                isChange = true;
                prevIsOnSub = value;
            }
        }
    }

    private Vector3 localMousePos; 
    private Vector2 defaultPivot = new Vector2(0.5f, 0.5f);
    private Vector2 prevPivot;
    private Vector2 newPivot;
    private Vector3 originalPosition;
    private void Awake()
    {
        stateMachine = new DragStateMachine(this);
    }
    private void Start()
    {
        mouse = GameSceneManager.Instance.GetComponent<MousePositionController>();
        rectTransform = GetComponent<RectTransform>();
        main = UtilGeneric.FindChildByName(this.gameObject, "MainImage");
        sub = UtilGeneric.FindChildByName(this.gameObject, "SubImage");
        mainShadow = main.GetComponent<Shadow>();
        subShadow = sub.GetComponent<Shadow>();
        mainShadow.enabled = false;
        subShadow.enabled = false;

        Initialize();
    }

    void Initialize()
    {
        stateMachine.ChangeState(stateMachine.firstState);        
    }
    private void Update()
    {
        stateMachine.Update();
        //Debug.Log($"{gameObject.name} : {stateMachine.currentState.ToString()}");
    }
    public void ResetState()
    {
        mainShadow.enabled = false;
        subShadow.enabled = false;

        stateMachine.ChangeState(stateMachine.firstState);
        isChange = false;
        isMove = false;
    }
    
    public void UIOnPointerDown()
    {
        transform.parent.SetAsLastSibling();    // parent는 캔버스다.
        mainShadow.enabled = true;
        subShadow.enabled = true;
        isClickSubDesk = IsOnSub;
    }

    public void UIOnDrag()
    {
        transform.position = mouse.worldPos;
        IsOnSub = mouse.IsOnSub;
        isMove = true;
    }

    public void NewPivot()
    {        
        localMousePos = transform.position - mouse.worldPos;

        newPivot.x = -(localMousePos.x / rectTransform.rect.width) + 0.5f;
        newPivot.y = -(localMousePos.y / rectTransform.rect.height) + 0.5f;
        rectTransform.pivot = newPivot;
        prevPivot = rectTransform.pivot;
    }
    public void ResetPivot()
    {
        rectTransform.pivot = prevPivot;
    }
    public void DefaultPivot()
    {
        prevPivot = rectTransform.pivot;
        rectTransform.pivot = defaultPivot;
    }
    public void SetPosition()
    {
        originalPosition = transform.position + localMousePos;
        rectTransform.pivot = defaultPivot;
        transform.position = originalPosition;
    }
    public void SetPositionNoChange()
    {
        originalPosition = transform.position;
        rectTransform.pivot = defaultPivot;
        transform.position = originalPosition;
    }

    void UpdateIsOnSub(bool isOnSub)
    {
        main.SetActive(!isOnSub);
        sub.SetActive(isOnSub);
        mainShadow.enabled = !isOnSub;
        subShadow.enabled = isOnSub;        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UIOnPointerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isChange) // 2. 드래그로 데스크를 옮겼을 때
        {
            if (isClickSubDesk == IsOnSub) // 3. 옆 데스크로 옮겼다가 다시 돌아왔을 때
            {
                // 3. 실행
                SetPosition();
                ResetState();
                return;
            }
            // 2. 실행
            ResetState();
            return;
        }
        // 1. 제자리에서 실행
        if (isMove) SetPosition();
        else SetPositionNoChange();
        ResetState();
        return;        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        NewPivot();
    }

    public void OnDrag(PointerEventData eventData)
    {
        UIOnDrag();        
    }
}