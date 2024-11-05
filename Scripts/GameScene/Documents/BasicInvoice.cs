using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DocumentInterface;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class BasicInvoice : Document, IStickerable, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    BasicInvoiceData data;
    public new BIStateMachine stateMachine;
       
    public string TrackingNumber { get { return data.TrackingNumber; } set { data.TrackingNumber = value; } }       // 운송장 번호
    public PersonInfo Sender { get { return data.Sender; } set { data.Sender = value; } }          // 보내는 사람
    public PersonInfo Recipient { get { return data.Recipient; } set { data.Recipient = value; } }       // 받는 사람
    public List<string> ParcelContents { get { return data.ParcelContents; } set { data.ParcelContents = value; } }// 택배 내용물
    
    public List<int> Quantity { get { return data.Quantity; } set { data.Quantity = value; } }          // 택배 수량
    public float Weight { get { return data.Weight; } set { data.Weight = value; } }              // 중량
    //public int Fare { get { return data.Fare; } set { data.Fare = value; } }                  // 택배 요금
    public bool HasSenderSignature { get { return data.HasSenderSignature; } set { data.HasSenderSignature = value; } }     // 발송인 서명

    private bool isSticker;
    public bool IsSticker {  get { return isSticker; } set {  isSticker = value; } }
    public bool IsCut { get; set; }
    public static bool isDraggingHandled = false;
    public static bool isDraggingSub = false;

    [Header("Text Elements")]
    public TMP_Text[] textElements;

    [Header("Image")]
    public Image signatureImage;
    public Image image;

    private GameObject myCanvas;
    public DraggableUIElement drag;

    protected override void Awake()
    {
        base.Awake();
        if (textElements == null)
        {
            textElements = new TMP_Text[11];
        }
    }

    protected override void Start()
    {
        base.Start();
        myCanvas = transform.parent.gameObject;
        drag = GetComponent<DraggableUIElement>();

        stateMachine = new BIStateMachine(this);
        base.stateMachine = stateMachine;
        stateMachine.ChangeState(stateMachine.firstState);

        GameSceneManager.Instance.eventSubject.OnStampImage += SetActiveStamps;
    }

    public void ResetState()
    {
        stateMachine.Flags.FalseAll();
        stateMachine.ChangeState(stateMachine.firstState);

        drag.main.gameObject.SetActive(false);
        drag.sub.gameObject.SetActive(true);
    }

    void Update()
    {
        stateMachine.Update();

        
    }

    protected override void UpdateUI()
    {
        base.customerData = GameSceneManager.Instance.currentCustomerData;
        data = base.customerData.basicInvoiceData;
        if (data == null) return;

        if (textElements == null || textElements.Length < 11)
        {
            Debug.Log("BasicInvoice Text Elements 부족");
            return;
        }

        textElements[0].text = TrackingNumber;
        textElements[1].text = Sender.Name;
        textElements[2].text = Sender.Address;
        //textElements[3].text = Sender.Contact;
        textElements[4].text = Recipient.Name;
        textElements[5].text = Recipient.Address;
        //textElements[6].text = Recipient.Contact;
        textElements[7].text = string.Join("\n", ParcelContents);
        textElements[8].text = string.Join("\n", Quantity);
        textElements[9].text = Weight.ToString("0") + "kg";
        //textElements[10].text = Fare + "원";

        //LoadPhoto();
    }

    private void LoadPhoto()
    {
        string imagePath = HasSenderSignature ? "Signature/" + Sender.Name : "Seal/fakeSeal";
        Sprite loadSprite = Resources.Load<Sprite>(imagePath);

        if (loadSprite != null)
        {
            signatureImage.sprite = loadSprite;
        }
        else
        {
            Debug.LogWarning("이미지를 로드할 수 없습니다: " + imagePath);
        }
    }


    public void SetActiveStamps()
    {
        if (GameSceneManager.Instance.stampA.stamps.Count != 0)
        {
            foreach (var item in GameSceneManager.Instance.stampA.stamps)
            {
                item.gameObject.SetActive(!drag.IsOnSub);
            }
        }
        if (GameSceneManager.Instance.stampB.stamps.Count != 0)
        {
            foreach (var item in GameSceneManager.Instance.stampB.stamps)
            {
                item.gameObject.SetActive(!drag.IsOnSub);
            }
        }
    }

    public void AttachSticker()
    {
        this.transform.SetParent(GameSceneManager.Instance.parcel.transform);
        GameSceneManager.Instance.dropZone.EnableCollectZone();
        RaycastDisabled();
        GameSceneManager.Instance.eventSubject.EventPutSticker();
    }

    public void RemoveSticker()
    {
        this.transform.SetParent(myCanvas.transform);
        GameSceneManager.Instance.dropZone.DisableCollectZone();
        RaycastEnabled();
    }
    
    public void RaycastDisabled()
    {
        image.raycastTarget = false;
        foreach ( var item in textElements)
        {
            item.raycastTarget = false;
        }
    }
    public void RaycastEnabled()
    {
        image.raycastTarget = true;
        foreach (var item in textElements)
        {
            item.raycastTarget = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraggingHandled = true;
    }
    //public virtual void OnDrag(PointerEventData eventData)
    //{
    //    SetActiveStamps(!FindMousePlace.instance.inSubDesk);
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    //if (IsSticker)
    //    //{
    //    //    if (UtilUI.IsPointerOverSpecificUI(GameSceneManager.Instance.Parcel.imageObj, eventData))
    //    //    {
    //    //        AttachSticker();
    //    //    }
    //    //}
    //}
    public void OnEndDrag(PointerEventData eventData)
    {
        //if (GameSceneManager.Instance.isStamp && UtilUI.IsPointerOverSpecificUI(GameSceneManager.Instance.dropZone.returnZone, eventData))
        //{
        //    if (IsCut || IsSticker)
        //    {
        //        GameSceneManager.Instance.dropZone.DropToDesk(subObj.gameObject);
        //    }
        //    else
        //    {
        //        GameSceneManager.Instance.dropZone.DropToCustomer(subObj.gameObject);
        //    }
        //}       
        
        isDraggingHandled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsCut)
        {
            SetActiveStamps();
        }
    }
}