using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;


[RequireComponent(typeof(Image))]
/// <summary>
/// Abstract class that provide basic IPointerClick interface
/// Basically need to work with clickable elements in bonus screens
/// </summary>
public abstract class BonusElement : MonoBehaviour, IBonusElement
{
    protected Image targetGraphic;

    private const float animationModifier = 1.1f;
    private const float animationDuration = 0.05f;

    public Action OnClick;


    private void OnEnable()
    {
        OnClick += OnClickAnimation;

        if (targetGraphic == null)
            targetGraphic = GetComponent<Image>();
    }


    private void OnDestroy()
    {
        OnClick = null;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void OnClickAnimation()
    {
        targetGraphic.rectTransform.DOScale(transform.localScale * animationModifier, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}