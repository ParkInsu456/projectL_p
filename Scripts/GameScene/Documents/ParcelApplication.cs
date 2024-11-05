using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParcelApplication : Document // 택배 신청서
{
    ParcelApplicationData data;
    public new GeneralStateMachine stateMachine;
    public DraggableUIElement drag;


    public string CustomsNumber { get { return data.customsNumber; } set { data.customsNumber = value; } }        // 통관 번호
    public string TrackingNumber { get { return data.trackingNumber; } set { data.trackingNumber = value; } }        // 운송장 번호
    public float Weight { get { return data.Weight; } set { data.Weight = value; } }                // 중량
    public PersonInfo Recipient { get { return data.Recipient; } set { data.Recipient = value; } }       // 수취인
    public string ApplicationDate { get { return data.ApplicationDate; } set { data.ApplicationDate = value; } }       // 신청일자
    public List<string> ParcelContents { get { return data.ParcelContents; } set { data.ParcelContents = value; } } // 택배 내용물
    public List<int> Quantity { get { return data.Quantity; } set { data.Quantity = value; } }         // 택배 수량
    public ReceiptReason Purpose { get { return data.Purpose; } set { data.Purpose = value; } }       // 택배 목적, 배송 이유
    public string PersonalUseReason { get { return data.PersonalUseReason; } set { data.PersonalUseReason = value; } }     // 기타 배송 이유, ReceiptReason이 PersonalUse일 때 사용
    public bool OfficialSeal { get { return data.OfficialSeal; } set { data.OfficialSeal = value; } }         // 관리국 인장

    [Header("Text Elements")]
    public TMP_Text[] textElements;

    [Header("Image")]
    public Image sealImage;

    [Header("Toggles")]
    public Toggle giftTogs;
    public Toggle documentsTogs;
    public Toggle foodTogs;
    public Toggle urgentGoodsTogs;
    public Toggle personalUseTogs;

    protected override void Awake()
    {
        base.Awake();
        if (textElements == null)
        {
            textElements = new TMP_Text[8];
        }

        if (sealImage == null)
        {
            Debug.LogWarning("sealImage가 설정되지 않았습니다.");
        }
    }
    protected override void Start()
    {
        base.Start();
        drag = GetComponent<DraggableUIElement>();

        stateMachine = new GeneralStateMachine(this);
        base.stateMachine = stateMachine;
        stateMachine.ChangeState(stateMachine.firstState);
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
        data = base.customerData.parcelApplicationData;
        if (data == null) return;

        if (textElements == null || textElements.Length < 8)
        {
            Debug.Log("BasicInvoice Text Elements 부족");
            return;
        }

        textElements[0].text = CustomsNumber;
        textElements[1].text = TrackingNumber;
        textElements[2].text = Weight + "kg";
        textElements[3].text = Recipient.Name;
        textElements[4].text = ApplicationDate;
        textElements[5].text = string.Join("\n", ParcelContents);
        textElements[6].text = string.Join("\n", Quantity);
        textElements[7].text = (Purpose == ReceiptReason.PersonalUse ? PersonalUseReason : "");


        // ReceiptReason에 따라 체크박스 설정
        if (giftTogs != null && documentsTogs != null && foodTogs != null && 
            urgentGoodsTogs != null && personalUseTogs != null)
        {
            giftTogs.isOn = (Purpose == ReceiptReason.Gift);
            documentsTogs.isOn = (Purpose == ReceiptReason.Documents);
            foodTogs.isOn = (Purpose == ReceiptReason.Food);
            urgentGoodsTogs.isOn = (Purpose == ReceiptReason.UrgentGoods);
            personalUseTogs.isOn = (Purpose == ReceiptReason.PersonalUse);

            // 비활성화 처리
            giftTogs.interactable = false;
            documentsTogs.interactable = false;
            foodTogs.interactable = false;
            urgentGoodsTogs.interactable = false;
            personalUseTogs.interactable = false;
        }

        //LoadPhoto();
    }

    private void LoadPhoto() // Resources 폴더에서 Name과 같은 이름의 파일 가져오기
    {
        string imageName = OfficialSeal ? "OfficialSeal" : "fakeSeal";
        string imagePath = "Seal/" + imageName;
        Sprite loadSprite = Resources.Load<Sprite>(imagePath);

        if (loadSprite != null)
        {
            sealImage.sprite = loadSprite;
        }
        else
        {
            Debug.LogWarning("이미지를 로드할 수 없습니다: " + imagePath);
        }
    }
}