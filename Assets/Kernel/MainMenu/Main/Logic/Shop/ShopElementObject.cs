using TMPro;
using UnityEngine;

public class ShopElementObject : ClickableElement
{
    [SerializeField] private TextMeshProUGUI priceText, nameText;

    [SerializeField] private ShopElementObjectFull shopElementObjectFull;

    public ShopElement currentElementSettings;

    public void SetupMiniature(ShopElement elementSettings)
    {
        currentElementSettings = elementSettings;

        targetGraphic.sprite = elementSettings.MiniImage;
        priceText.text = elementSettings.isPurchased ? "Purchased" : $"{elementSettings.Price} <sprite=0>";
        nameText.text = elementSettings.Name;

        OnClick = null;
    }

    public void UpdateMiniature()
    {
        targetGraphic.sprite = currentElementSettings.MiniImage;
        priceText.text = "Purchased";
        nameText.text = currentElementSettings.Name;

        OnClick = null;
    }

    public void DisableElement()
    {
        targetGraphic.enabled = false;
    }

    public void EnableElement()
    {
        targetGraphic.enabled = true;
    }
}