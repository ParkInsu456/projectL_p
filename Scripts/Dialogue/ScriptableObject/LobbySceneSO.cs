using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterSO",  menuName = "ScriptableObject/LobbyScene/ChracterSO", order = 0)]
public class LobbySceneSO : ScriptableObject
{
    [Header("ĳ���� ����")]
    public string characterName;
    [Tooltip("A~F ������ �����ڸ� ���� ��ȣ, A�� 100, F�� 600")]
    public int characterNum;

    [Space (10f)]
    public Sprite lobbyImage;
    public Sprite dialogueImage;

}

