using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : ClickableElement
{
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private Color defaultColor, moneyColor;
    [SerializeField] private Sprite buySprite, closeColor;

    public void SetupButton(bool isEnoughMoney)
    {
        if (isEnoughMoney)
        {
            targetGraphic.sprite = buySprite;
            mainText.text = "Buy";
        }
        else
        {
            targetGraphic.sprite = closeColor;
            mainText.text = "Close";
        }
    }   

    public void UpdateText()
    {
        mainText.text = "Purchased!";
    }
}