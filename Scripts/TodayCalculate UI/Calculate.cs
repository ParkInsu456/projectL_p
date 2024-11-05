using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    [Header("텍스트 설정용 TMP")]
    public TextMeshProUGUI totalMoneyText;
    public TextMeshProUGUI percelCountText;
    public TextMeshProUGUI failCountText;
    public TextMeshProUGUI livingText; // 생활비
    public TextMeshProUGUI loanText; // 대출금
    public TextMeshProUGUI profitText; //총 수익

    [Header("애니메이션 용 설정")]

    public CanvasGroup canvas;
    public Image background;

    [Header("전체 텍스트 그룹")]
    public CanvasGroup title;
    public CanvasGroup description;
    public CanvasGroup totalMoney;
    public CanvasGroup parcel;
    public CanvasGroup fail;
    public CanvasGroup living;
    public CanvasGroup loan;
    public CanvasGroup profit;

    [Space]
    public Image line;
    public CanvasGroup button;

    [Header("날짜")]
    public CanvasGroup todayDate;
    public TextMeshProUGUI date;
    public TextMeshProUGUI dateCount;


    //하드코딩 값

    private int intDefaultMoney = 1000; 
    private int intLiving = 1000; 
    private int intLoan = 1000; 
    private int intMoney = 5000;


    public PlayData _playdata => GameManager.Instance.playData;


    private void Awake()
    {
        //오브젝트 알파 전부 0으로 세팅
        //오브젝트 꺼두기
        Debug.Log("로비 UI 세팅 초기화");
        SetallObjectAlphaToZero();
        SetFalseCalculate();
    }

    /// <summary>
    /// 정산 내용을 애니메이션을 통해 보여줍니다.
    /// </summary>
    public void ShowCalculateAnimation()
    {
        SetTrueCalculate();
        SetCalculateText();
        background.DOFade(1, 1.5f).SetEase(Ease.InOutQuad).OnComplete(ShowText);
    }

    /// <summary>
    /// 텍스트와 버튼을 순서대로 보여줍니다.
    /// </summary>
    private void ShowText()
    {
        title.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(0.2f);
        description.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(0.4f);
        totalMoney.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(0.6f);
        parcel.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(0.8f);
        fail.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(1f);
        living.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(1.2f);
        loan.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(1.4f);
        line.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(1.8f);
        profit.DOFade(1, 0.3f).SetEase(Ease.InOutSine).SetDelay(2.2f);

        button.DOFade(1, 1f).SetEase(Ease.InOutSine).SetDelay(3f);
    }

    private void CloseText()
    {
        title.DOFade(0, 1f).SetEase(Ease.InOutSine);
        description.DOFade(0, 1f).SetEase(Ease.InOutSine);
        totalMoney.DOFade(0, 1f).SetEase(Ease.InOutSine);
        parcel.DOFade(0, 1f).SetEase(Ease.InOutSine);
        fail.DOFade(0, 1f).SetEase(Ease.InOutSine);
        living.DOFade(0, 1f).SetEase(Ease.InOutSine);
        loan.DOFade(0, 1f).SetEase(Ease.InOutSine);
        line.DOFade(0, 1f).SetEase(Ease.InOutSine);
        profit.DOFade(0, 1f).SetEase(Ease.InOutSine);
        button.DOFade(0, 1f).SetEase(Ease.InOutSine);
    }

    /// <summary>
    /// 하루 정산 내용을 설정합니다.
    /// </summary>
    private void SetCalculateText()
    {
        totalMoneyText.text = _playdata.Gold.ToString();
        percelCountText.text = "+ " + (intDefaultMoney * _playdata.Customer).ToString();
        failCountText.text = "-" + (intDefaultMoney * _playdata.Failed).ToString();
        livingText.text = "-" + intLiving.ToString();
        loanText.text = "-" + intLoan.ToString();

        intMoney = _playdata.Gold + (intDefaultMoney * _playdata.Customer) - (intDefaultMoney * _playdata.Failed) - intLiving - intLoan;

        profitText.text = intMoney.ToString();

        _playdata.Gold = intMoney;
    }

    /// <summary>
    /// 날짜 애니메이션 실행.
    /// </summary>
    public void ShowTodayDate()
    {
        int intdate = GameManager.Instance.date + 1;

        if (intdate < 10)
        {
            date.text = "2010. 09. 0" + intdate.ToString();
        }
        else
        {
            date.text = "2010. 09. " + intdate.ToString();
        }

        dateCount.text = intdate.ToString() + "일차";

        if (title.alpha == 1){  CloseText(); };
        background.color = new Color(0, 0, 0, 1);

        todayDate.DOFade(1, 0.5f).SetEase(Ease.InOutSine).SetDelay(1.2f);
        todayDate.DOFade(0, 0.5f).SetEase(Ease.InOutSine).SetDelay(3f).OnComplete(CloseCalculate);

    }

    /// <summary>
    /// 오브젝트 알파를 전부 끄는 함수입니다. 애니메이션 시작 전에 실행하세요.
    /// </summary>
    public void SetallObjectAlphaToZero()
    {
        background.color = new Color(0, 0, 0, 0);
        title.alpha = 0;
        description.alpha = 0;
        totalMoney.alpha = 0;
        parcel.alpha = 0;
        fail.alpha = 0;
        living.alpha = 0;
        loan.alpha = 0;
        line.color = new Color(1, 1, 1, 0);
        profit.alpha = 0;
        button.alpha = 0;
        todayDate.alpha = 0;
    }

    private void CloseCalculate()
    {
        canvas.DOFade(0, 1f).SetEase(Ease.InOutSine).OnComplete(SetFalseCalculate);

    }

    public void SetFalseCalculate() { canvas.gameObject.SetActive(false); }
    public void SetTrueCalculate() 
    {
        canvas.alpha = 1;
        canvas.gameObject.SetActive(true); 
    }

}
