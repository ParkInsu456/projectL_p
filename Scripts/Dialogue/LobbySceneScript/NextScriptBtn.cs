using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class NextScriptBtn : MonoBehaviour, IShowNextScript
{
    public string[] selectionA;
    public string[] selectionB;

    LobbyScriptController lobbyManager => LobbyScriptController.Instance;
    public int count => lobbyManager.count;

    public void BtnClick()
    {
        //���� �κ�Ŵ����� startSelectionNum�� count�� �Ȱ��� ��, 
        //�������� N�� �����ش�. (SelectionNum�� ������ ���� ����)
        //���������� n�� ������ ��´�.

        lobbyManager.count++;

        if (lobbyManager.contentSave.Length > count)
        {
            ShowNextScript();

            //���� ������ ��ȣ�� ���� �ֽ� ��ȣ�� count�� �����ϴٸ� ����
            if (lobbyManager.selectionNum == null) return;

            if (lobbyManager.selectionNum.Length <= lobbyManager.startSelectionNum && 
                lobbyManager.selectionNum[lobbyManager.startSelectionNum] == count)
            {
                Debug.Log("������ �Լ� ����");
                lobbyManager.SetSelectionContent(count);
                //lobbyManager.lobbyAnimation.ShowSelectionUI();
            }
            else
            {
                lobbyManager.lobbyAnimation.ShowSquareBtn();
            }
        }
        else
        {
            lobbyManager.lobbyAnimation.CloseCharacterDialogueScreen();
            lobbyManager.ClearStringArray();

        }

    }

    public void ShowNextScript()
    {
        lobbyManager.lobbyAnimation.SetContentAlphaZero();
        lobbyManager.SetDialogueContent(count);
        lobbyManager.lobbyAnimation.PlayContentAnimation();
    }

    
}
