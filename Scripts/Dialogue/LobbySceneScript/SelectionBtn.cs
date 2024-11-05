using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IShowNextScript
{
    void ShowNextScript();
}

public class SelectionBtn : MonoBehaviour, IShowNextScript
{
    [Header("���� ��ȣ�� �̵�")]
    public int nextNum;

    public int count => lobbyManager.count;

    LobbyScriptController lobbyManager => LobbyScriptController.Instance;
    public void SelectionBtnClick()
    {
        //count�� ��ȣ�� �̵�.
        //BtnClick ����.

        lobbyManager.count = nextNum;
        lobbyManager.lobbyAnimation.CloseSelectionUI();
        ShowNextScript();
    }
    public void ShowNextScript()
    {
        lobbyManager.lobbyAnimation.SetContentAlphaZero();
        lobbyManager.SetDialogueContent(count);
        lobbyManager.lobbyAnimation.PlayContentAnimation();
    }

}
