using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ParcelPermit : Document // 택배물 허가서
{
    ParcelPermitData data;
    public new GeneralStateMachine stateMachine;
    public DraggableUIElement drag;


    public string Name { get { return data.Name; } set { data.Name = value; } }          // 이름
    public string DateOfBirth { get { return data.DateOfBirth; } set { data.DateOfBirth = value; } }    // 생년월일
    public string TrackinNumber { get { return data.TrackingNumber; } set { data.TrackingNumber = value; } }   // 운송장 번호
    public string IssueDate { get { return data.IssueDate; } set { data.IssueDate = value; } }       // 발급일자
    public string ExpiryDate { get { return data.ExpiryDate; } set { data.ExpiryDate = value; } }      // 만료일자
    public bool OfficialSeal { get { return data.OfficialSeal; } set { data.OfficialSeal = value; } }    // 관리국 인장

    [Header("Text Elements")]
    public TMP_Text[] textElements;

    [Header("Image")]
    public Image sealImage;

    protected override void Awake()
    {
        base.Awake();
        if (textElements == null)
        {
            textElements = new TMP_Text[5];
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
        data = base.customerData.parcelPermitData;
        if (data == null) return;

        if (textElements == null || textElements.Length < 5)
        {
            Debug.Log("Text Elements 부족");
            return;
        }

        textElements[0].text = Name;
        textElements[1].text = FormatDateOfBirth(DateOfBirth);
        textElements[2].text = TrackinNumber;
        textElements[3].text = IssueDate;
        textElements[4].text = ExpiryDate;

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

    private string FormatDateOfBirth(string rrn)
    {
        if (string.IsNullOrEmpty(rrn) || rrn.Length != 13 || rrn[6] != '-')
        {
            Debug.LogWarning("잘못된 주민등록번호 형식입니다.");
            return rrn;
        }

        // RRN 연도, 월, 일 추출
        string year = rrn.Substring(0, 2);
        string month = rrn.Substring(2, 2);
        string day = rrn.Substring(4, 2);

        return $"{year}. {month}. {day}.";
    }
}