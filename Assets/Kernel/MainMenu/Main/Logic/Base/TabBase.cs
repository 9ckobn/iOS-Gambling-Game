using UnityEngine;
using UnityEngine.UI;

public class TabBase : ClickableElement
{
    [SerializeField] private UIScreen currentScreen;
    [SerializeField] private Sprite selectedSprite;
    [SerializeField, Tooltip("If no reference, default sprite will be get from current sprite on image")] private Sprite defaultSprite;
    [HideInInspector] public TabSelector MainSelector;

    void Start()
    {
        if (defaultSprite == null)
            defaultSprite = targetGraphic.sprite;
    }

    public void SetupCurrentScreen()
    {
        targetGraphic.sprite = selectedSprite;
        currentScreen.StartScreen();
    }

    public void CloseCurrentScreen()
    {
        currentScreen.CloseScreen();
        targetGraphic.sprite = defaultSprite;
    }
}
