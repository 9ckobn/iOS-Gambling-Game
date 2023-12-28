using UnityEngine;

public class Block : ClickableElement
{
    public bool trueBlock = false;
    [SerializeField] private Sprite sprite;

    public RectTransform myRect;

    void Start()
    {
        needToAnimate = false;
        myRect = GetComponent<RectTransform>();
    }

    public void EnableBlock()
    {
        OnClick += OnClickAnimation;
    }

    public void SetupLoseGraphicOnClick()
    {
        OnClick += ChangeSprite;
    }

    public void ChangeSprite()
    {
        if (!trueBlock) targetGraphic.sprite = sprite;

        OnClick = null;
    }
}