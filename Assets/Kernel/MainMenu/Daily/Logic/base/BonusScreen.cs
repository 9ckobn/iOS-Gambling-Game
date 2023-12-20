using System;
using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract class that provide basic logic for all of bonus screens
/// </summary>
public abstract class BonusScreen : MonoBehaviour
{
    private Image[] allGraphicObjects;
    [SerializeField] private TextMeshProUGUI[] additionalGraphicToFade;

    private Color32 baseColor = new Color32(255, 255, 255, 0);

    [SerializeField] private float fadeDuration = 0.3f;

    protected DailyBonusScreen ParentScreen;

    public void SetupScreen(DailyBonusScreen dbs)
    {
        ParentScreen = dbs;

        allGraphicObjects = GetComponentsInChildren<Image>();

        OpenWithAnimation();
        
        StartScreen();
    }

    public abstract void StartScreen();

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }

    public async UniTask CloseScreenWithAnimation()
    {
        foreach (var item in allGraphicObjects)
        {
            item.DOFade(0, fadeDuration);
        }        

        foreach (var item in additionalGraphicToFade)
        {
            item.DOFade(0, fadeDuration);
        }

        await UniTask.Delay((int)(fadeDuration * 1000));

        gameObject.SetActive(false);
    }

    public async UniTask CloseScreenWithAnimation(int timeOutToStart)
    {
        await UniTask.Delay(timeOutToStart);

        foreach (var item in allGraphicObjects)
        {
            item.DOFade(0, fadeDuration);
        }

        foreach (var item in additionalGraphicToFade)
        {
            item.DOFade(0, fadeDuration);
        }

        await UniTask.Delay((int)(fadeDuration * 1000));

        gameObject.SetActive(false);
    }


    private void OpenWithAnimation()
    {
        gameObject.SetActive(true);

        foreach (var item in allGraphicObjects)
        {
            item.color = baseColor;
            item.DOFade(1, fadeDuration);  
        }
    }


}