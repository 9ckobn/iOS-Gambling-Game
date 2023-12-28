using TMPro;
using UnityEngine;

public class MainButton : ClickableElement
{
    [SerializeField] private TextMeshProUGUI buttonText;

    public virtual void ChangeSprite(Sprite sprite) => targetGraphic.sprite = sprite;

    public virtual void ChangeText(string text)
    {
        if (buttonText != null)
            buttonText.text = text;
        else
            Debug.Log("here is no text component");
    }
}