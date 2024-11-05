using TMPro;
using UnityEngine;
using UnityEngine.UI;
//�ð��븦 ����Ű�� enum, am�� ���� �÷��� ��, pm�� ���� �÷��� ���� �Դϴ�.
public enum DateTimeInLobby
{
    AM = 0,
    PM = 1000
}

public class LobbyScriptController : MonoBehaviour
{
    private static LobbyScriptController _instance;
    public static LobbyScriptController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("AnimationControl").AddComponent<LobbyScriptController>();

            }
            return _instance;
        }
    }
    private CSVReader cSVReader;
    public LobbyAnimation lobbyAnimation;
    private Calculate calculate;

    [SerializeField]
    public int date;
    public DateTimeInLobby datetime;

    [Header("��ȭȭ�� Text")]
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterContent;
    public int count;

    [Header("�޾ƿ� ��� Ȯ�ο�")]
    public string[] contentSave;
    public string[] selectionSave;

    [Header("������ ��ȣ ����")]
    public int[] selectionNum;
    public int startSelectionNum;

    [Header("������ ����")]
    public GameObject selectionA;
    public GameObject selectionB;
    public TextMeshProUGUI selectionATxt;
    public TextMeshProUGUI selectionBTxt;

    [Header("Button")]
    public Button btnWork;
    public Button btnGoHome;
    public Button btnDoneGoHome;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance == this)
            {
                Destroy(gameObject);
            }
        }

        lobbyAnimation = GetComponent<LobbyAnimation>();
        cSVReader = GetComponent<CSVReader>();
        calculate = GetComponent<Calculate>();
    }

    private void Start()
    {
        //�ӽ÷� ��¥�� 1����, AM���� �����߽��ϴ�. ���߿� �����ؼ� ����
        date = GameManager.Instance.date;
        datetime = GameManager.Instance.datetime;

        if(datetime == DateTimeInLobby.AM)
        {
            btnGoHome.gameObject.SetActive(false);
            btnWork.gameObject.SetActive(true);

            calculate.SetTrueCalculate();
            calculate.ShowTodayDate();
        }
        else if(datetime == DateTimeInLobby.PM) 
        {
            btnGoHome.gameObject.SetActive(true);
            btnWork.gameObject.SetActive(false);
        }
        btnDoneGoHome.enabled = true;
    }

    /// <summary>
    /// ���̾�α׸� �о�ͼ� �����մϴ�.
    /// </summary>
    public void GetDialogueResource(int CharacterNum)
    {
        contentSave = cSVReader.FindDialogueScriptData(CharacterNum + date + (int)datetime + 1);
        selectionSave = cSVReader.FindSelectionScriptData(CharacterNum + date + (int)datetime+ 1);
    }

    /// <summary>
    /// ȭ���� �۾��� ������ ��ȣ�� ���缭 �����մϴ�.
    /// </summary>
    /// <param name="num"></param>
    public void SetDialogueContent(int num)
    {
        string[] splitString = contentSave[num].Split('\t');
        characterName.text = splitString[0];
        characterContent.text = splitString[1].Replace("\"", "");
    }

    /// <summary>
    /// �����ϴ� ��ȭ ���ǿ��� �����ϴ� ������ ��ȣ�� ã���ϴ�.
    /// </summary>
    public int[] FindSelectionNum()
    {
        if(selectionSave != null)
        {
            string newNum = null;
            int[] num = new int[selectionSave.Length];

            for(int i = 0; i < selectionSave.Length; i++)
            {
                newNum = selectionSave[i].Split("\t")[0];
                num[i] = int.Parse(newNum);
            }
            return num;
        }
        return null;
    }

    /// <summary>
    /// ȭ���� �۾��� ������ ������ ��ȣ�� ���缭 �����մϴ�.
    /// </summary>
    /// <param name="num"></param>
    public void SetSelectionContent(int num)
    {
        if (selectionNum[startSelectionNum] == num)
        {
            string[] split = selectionSave[startSelectionNum].Split("\t");
            selectionATxt.text = split[1];
            selectionA.GetComponent<SelectionBtn>().nextNum = int.Parse(split[2]);
            startSelectionNum++;
            if (selectionNum.Length <= startSelectionNum && selectionNum[startSelectionNum] == num)
            {
                split = selectionSave[startSelectionNum].Split("\t");
                selectionBTxt.text = split[1];
                selectionB.GetComponent<SelectionBtn>().nextNum = int.Parse(split[2]);
                startSelectionNum++;
            }
        }
    }

    /// <summary>
    /// ���̺��ص� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    public void ClearStringArray()
    {
        contentSave = null;
        selectionSave = null;
        selectionNum = null;
        startSelectionNum = 0;
        count = 0;
    }

    /// <summary>
    /// �κ� �´� ĳ���� �Ϸ���Ʈ�� �����ͼ� ��ġ�մϴ�.
    /// </summary>
    private void GetResource()
    {
        //TODO : DateInfo CSV Ȯ���ؼ� �ʿ� �ִ� MPCȮ��, ��¥�� �ð��� �°� �ʿ� ��ġ
    }


    public void BtnGotoHome()
    {
        calculate.ShowCalculateAnimation(); // �ִϸ��̼� ����
    }

    public void RealGoToHome()
    {
        GameManager.Instance.NextDay();
        btnGoHome.gameObject.SetActive(false);
        btnWork.gameObject.SetActive(true);
        btnDoneGoHome.enabled = false;

        date = GameManager.Instance.date;
        datetime = GameManager.Instance.datetime;

        calculate.ShowTodayDate();
        // ���� �κ�� �ε�...?
        // �׳� ��� ����? �� �κ� �״�� ����
    }

    public void BtnEnabled()
    {
        if(datetime == DateTimeInLobby.AM)
        {
            btnWork.gameObject.SetActive(true);
        }
        else
        {
            btnGoHome.gameObject.SetActive(true);            
        }
    }
    public void BtnDisabled()
    {
        if (datetime == DateTimeInLobby.AM)
        {
            btnWork.gameObject.SetActive(false);
        }
        else
        {
            btnGoHome.gameObject.SetActive(false);
        }
    }
}
