using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneChanger : MonoBehaviour
{
    public Image background;
    public static FadeSceneChanger Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance == this)
            {
                Destroy(gameObject);
            }
        }

        if (background == null)
        {
            background = new GameObject("background").AddComponent<Image>();
            background.gameObject.transform.SetParent(gameObject.transform, false);
            background.rectTransform.anchorMin = new Vector2(0, 0);
            background.rectTransform.anchorMax = new Vector2(1, 1);
            background.rectTransform.pivot = new Vector2(1, 1);
            background.rectTransform.sizeDelta = new Vector2(0, 0);
            background.color = new Color(0, 0, 0, 1);
            background.raycastTarget = false;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (scene.name == "GameScene")
        {
            OpenScreenShutter();
        }
        else
        {
            OpenScreenFade();
        }
    }

    public void CloseScreen(string SceneName)
    {
        background.DOFade(1, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => LoadScene(SceneName));
    }

    public void OpenScreenFade()
    {
        background.DOFade(0, 1f).SetEase(Ease.InOutSine).SetDelay(0.5f);
    }

    public void OpenScreenShutter()
    {
        background.rectTransform.DOScaleY(0, 1f).SetEase(Ease.InOutQuart).SetDelay(0.5f);
    }
    public void CloseScreenShutter(string SceneName)
    {
        background.rectTransform.DOScaleY(1, 1.5f).SetEase(Ease.InOutQuart).OnComplete(() => LoadScene(SceneName));
    }

    public void LoadScene(string sceneName) // 씬 이름 문자열로 받아서 해당 씬 로드
    {
        SceneManager.LoadScene(sceneName);
    }

}
