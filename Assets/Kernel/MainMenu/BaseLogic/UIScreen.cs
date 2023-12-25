using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Abstract class that provide basic logic for all of bonus screens
/// </summary>
public abstract class UIScreen : MonoBehaviour
{
    private Image[] allGraphicObjects;
    private TextMeshProUGUI[] additionalGraphicToFade;

    private Color32 baseColor = new Color32(255, 255, 255, 0);

    [SerializeField] private AnimationType animationType = AnimationType.Fade;
    [SerializeField] private float fadeDuration = 0.3f;

    private void OnEnable()
    {
        if (animationType != AnimationType.None)
        {
            allGraphicObjects = GetComponentsInChildren<Image>();
            additionalGraphicToFade = GetComponentsInChildren<TextMeshProUGUI>();
        }

        OpenScreen();
    }

    public abstract void StartScreen();

    public virtual void CloseScreen()
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


    private void OpenScreen()
    {
        switch (animationType)
        {
            case AnimationType.Fade:
                FadeInAnimation();
                break;
            case AnimationType.None:
                break;
        }
    }

    private void FadeInAnimation()
    {
        foreach (var item in allGraphicObjects)
        {
            item.color = baseColor;
            item.DOFade(1, fadeDuration);
        }

        foreach (var item in additionalGraphicToFade)
        {
            item.DOFade(1, fadeDuration);
        }
    }
}

public enum AnimationType
{
    Fade,
    None
}