using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LobbyAnimation : MonoBehaviour
{

    [Header("��ȭȭ�� �� ���ϴ� UI���")]
    public Image blackBoxUITop;
    public Image blackBoxUIBottom;
    public Image dialogueMPCImage;

    [Header("text �ִϸ��̼ǿ�")]
    public GameObject AllTextUI;
    private Button textUIBtn;
    public CanvasGroup nameCanvasGroup;
    public CanvasGroup contentCanvasGroup;
    public Image squareBtn;

    [Header("������ ����")]
    public CanvasGroup selection;

    LobbyScriptController lobbyManager => LobbyScriptController.Instance;

    private void Awake()
    {
        textUIBtn = AllTextUI.GetComponent<Button>();
    }

    private void Start()
    {
        SetTextGroupActiveFalse();
        SetSeiectionActive(false);
        selection.alpha = 0;
    }

    /// <summary>
    /// ��ȭȭ���� ó�� �����մϴ�.
    /// </summary>
    public void ShowCharacterDialogueScreen()
    {
        SetContentAlphaZero();

        blackBoxUITop.rectTransform.DOSizeDelta(new Vector2(0, 110), 1f).SetEase(Ease.OutExpo);
        blackBoxUIBottom.rectTransform.DOSizeDelta(new Vector2(0, 300), 1f).SetEase(Ease.OutExpo);

        //TODO : ĳ���� �Ϸ���Ʈ ����

        SetTextGroupActiveTrue();
        OnOffBtnClick(true);
        nameCanvasGroup.DOFade(1, 1f).SetEase(Ease.OutExpo).SetDelay(0.5f);
        contentCanvasGroup.DOFade(1, 1f).SetEase(Ease.OutExpo).SetDelay(0.5f);
    }

    /// <summary>
    /// ��ȭȭ�鿡�� �����մϴ�. 
    /// </summary>
    public void CloseCharacterDialogueScreen()
    {
        OnOffBtnClick(false);
        nameCanvasGroup.DOFade(0, 0.5f).SetEase(Ease.OutExpo).OnComplete(SetTextGroupActiveFalse);
        contentCanvasGroup.DOFade(0, 0.5f).SetEase(Ease.OutExpo);

        blackBoxUITop.rectTransform.DOSizeDelta(new Vector2(0, 60), 1f).SetEase(Ease.OutExpo).SetDelay(0.5f);
        blackBoxUIBottom.rectTransform.DOSizeDelta(new Vector2(0, 60), 1f).SetEase(Ease.OutExpo).SetDelay(0.5f).OnComplete(() => lobbyManager.BtnEnabled());

        //TODO : ĳ���� �Ϸ���Ʈ close
    }

    /// <summary>
    /// �۾��� ������ �ʰ� ����ϴ�.
    /// </summary>
    public void SetContentAlphaZero()
    {
        CloseSquareBtn();
        contentCanvasGroup.alpha = 0f;
    }

    /// <summary>
    /// �÷��̾ ȭ���� Ŭ���� ��� ���� �۾��� �����ִ� �ִϸ��̼��Դϴ�.
    /// </summary>
    public void PlayContentAnimation()
    {
        contentCanvasGroup.DOFade(1, 1f).SetDelay(0.1f);
    }

    /// <summary>
    /// �������� �����մϴ�.
    /// </summary>
    public void ShowSelectionUI()
    {
        SetSeiectionActive(true);
        selection.alpha = 0;
        selection.DOFade(1, 0.5f).SetEase(Ease.OutExpo);
    }

    /// <summary>
    /// �������� ������ �ʰ� �ݽ��ϴ�.
    /// </summary>
    public void CloseSelectionUI()
    {
        SetSeiectionActive(false);
        selection.DOFade(0, 0.5f).SetEase(Ease.OutExpo);
    }

    public void ShowSquareBtn()
    {
        squareBtn.DOFade(1, 0.5f).SetEase(Ease.OutExpo).SetDelay(0.3f);
    }

    public void CloseSquareBtn()
    {
        squareBtn.DOFade(0, 0.1f).SetEase(Ease.OutExpo);
    }

    private void OnOffBtnClick(bool onOff) { textUIBtn.interactable = onOff; }

    private void SetSeiectionActive(bool onOff) { selection.interactable = onOff; }

    private void SetTextGroupActiveFalse() { AllTextUI.SetActive(false); }
    private void SetTextGroupActiveTrue() { AllTextUI.SetActive(true); }
}
