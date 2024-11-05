using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    
    public void OnMainSceneBtn() //특정 씬 로드
    {
        AudioManager.Instance.PlayClickSound();
        FadeSceneChanger.Instance.CloseScreen("MainScene");
    }

    public void OnSaveLoadSceneBtn()
    {
        AudioManager.Instance.PlayClickSound();
        FadeSceneChanger.Instance.CloseScreen("SaveLoadScene");
    }

    public void OnLobbySceneBtn()
    {
        AudioManager.Instance.PlayClickSound();
        FadeSceneChanger.Instance.CloseScreen("LobbyScene");
    }

    public void OnGameSceneBtn()
    {
        AudioManager.Instance.PlayClickSound();
        FadeSceneChanger.Instance.CloseScreen("GameScene");
    }

    public void OnCreditSceneBtn()
    {
        AudioManager.Instance.PlayClickSound();
        FadeSceneChanger.Instance.CloseScreen("CreditScene");
    }

}
