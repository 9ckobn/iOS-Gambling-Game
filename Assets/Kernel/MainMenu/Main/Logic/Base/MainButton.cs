using TMPro;
using UnityEngine;

public class MainButton : ClickableElement
{
    private DefaultNotification _mainScreen;
    [SerializeField] private TextMeshProUGUI buttonText;

    public void SetupButton(DefaultNotification mainScreen)
    {
        _mainScreen = mainScreen;
    }

    public void SetupCloseScreen()
    {
        _mainScreen.SetupCloseScreen();
    }

    public void ChangeSprite(Sprite sprite) => targetGraphic.sprite = sprite;

    public void ChangeText(string text)
    {
        if(buttonText != null)
            buttonText.text = text;
        else 
            Debug.Log("here is no text component");
    } 
}