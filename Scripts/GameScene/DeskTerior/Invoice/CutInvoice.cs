using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CutInvoice : MonoBehaviour
{
    public GameObject MainDesk; // 인스펙터 캐싱
    public GameObject BottomMainImage;
    public GameObject InvoiceLower;
    public GameObject lowerCanvas;
    private DraggableUIElement draggableUIElement;
    private Image cutImage;

    public SynkInvoice synkInvoice;

    private BasicInvoice basicInvoice;
    public Image mainInvoiceImage;
    public event Action OnCutEnd;

    private void Awake()
    {
        cutImage = GetComponent<Image>();
        synkInvoice = BottomMainImage.GetComponent<SynkInvoice>();
        basicInvoice = UtilGeneric.FindTInHierarchy<BasicInvoice>(gameObject);

        //InvoiceLower = GameObject.Find("Main_InvoiceLower").gameObject;
    }

    private void Start()
    {
        GameSceneManager.Instance.eventSubject.OnStamp += EnableImage;
        cutImage.enabled = false;
    }

    public void CuttingAnimation()  //송장 나누기. 버튼에서 실행
    {
        mainInvoiceImage.raycastTarget = false;
        basicInvoice.RaycastDisabled();
        basicInvoice.IsCut = true;

        transform.DOLocalMoveX(290, 1.5f).SetEase(Ease.InOutCubic).OnComplete(SetNextAnimation);
    }

    void SetNextAnimation()
    {
        MoveInvoiceParent();
    }

    void MoveInvoiceParent()
    {
        //InvoiceLower = BottomMainImage.transform.parent.gameObject;
        //InvoiceLower.transform.SetParent(MainDesk.transform);
        lowerCanvas.transform.SetParent(MainDesk.transform);
        MoveInvoiceLower();
    }

    void MoveInvoiceLower()
    {
        float transform = InvoiceLower.transform.position.y - 20;
        InvoiceLower.transform.DOLocalMoveY(transform, 0.8f).SetEase(Ease.OutExpo).OnComplete(SetOff);
    }

    void SetOff()
    {
        mainInvoiceImage.raycastTarget = true;
        basicInvoice.RaycastEnabled();
        OnCutEnd?.Invoke();
        GameSceneManager.Instance.eventSubject.EventCut();

        cutImage.enabled = false;
        synkInvoice.IsCut = true;

        draggableUIElement = InvoiceLower.AddComponent<DraggableUIElement>();
        InvoiceLower.AddComponent<FSMDragController>();
        //SubObjectEvent sub = SubInvoice.AddComponent<SubObjectEvent>();

        //SubInvoice.GetComponent<SubObjectEvent>().enabled = true;
       // InvoiceLower.GetComponent<DraggableUIElement>().enabled = true;
        //sub.Initialize();
        //main.Initialize();
    }
    

    // 되돌리기
    public void ResetInvoice()
    {
        draggableUIElement.sub.SetActive(false);
        //draggableUIElement.enabled = false;
        //SubInvoice.GetComponent<SubObjectEvent>().enabled = false;

        Destroy(InvoiceLower.GetComponent<DraggableUIElement>());
        Destroy(InvoiceLower.GetComponent<FSMDragController>());
        //Destroy(SubInvoice.GetComponent<SubObjectEvent>());

        synkInvoice.IsCut = false;
        basicInvoice.IsCut = false;
        cutImage.enabled = false;

        transform.localPosition = new Vector3(-277f, -125f, 0f);

        lowerCanvas.transform.SetParent(basicInvoice.transform);
        RectTransform rect = lowerCanvas.GetComponent<RectTransform>();
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;  // 캔버스의 사이즈가 바뀌어서 원래대로 되돌리는 코드
        transform.SetAsLastSibling();
        InvoiceLower.transform.localPosition = new Vector3(0f, -250f, 0f);
        BottomMainImage.gameObject.SetActive(true);
    }

    public void EnableImage()
    {
        cutImage.enabled = true;
    }
    public void DisableImage()
    {
        cutImage.enabled = false;
    }
}
