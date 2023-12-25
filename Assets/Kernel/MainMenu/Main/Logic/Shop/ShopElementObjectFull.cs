using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopElementObjectFull : UIScreen
{
    [SerializeField] private Image targetGraphic;
    [SerializeField] private TextMeshProUGUI elementName, price;

    [SerializeField] private Color priceColor, defaultColor;

    public ShopElementObject currentItem;

    public Action OnItemPurchased;

    private const string notEnough = "Not enough credits";

    public void SetupScreen(bool isEnoughMoney)
    {
        targetGraphic.sprite = currentItem.currentElementSettings.MiniImage;

        elementName.text = currentItem.currentElementSettings.Name;

        if (isEnoughMoney)
        {
            price.color = priceColor;
            price.text = $"{currentItem.currentElementSettings.Price} <sprite=0>";

            // mainButton.OnClick += () =>
            // {
            //     PurchaseItem(mainElement);
            // };
        }
        else
        {
            price.color = defaultColor;
            price.text = notEnough;

            //mainButton.SetupCloseScreen();
        }

        StartScreen();
    }

    public void PurchaseItem()
    {
        PlayerStats.MoneyCount -= currentItem.currentElementSettings.Price;

        currentItem.currentElementSettings.SetPurchased();
        currentItem.UpdateMiniature();

        // mainButton.ChangeText("Purchased");

        OnItemPurchased?.Invoke();
    }

    public override void StartScreen()
    {
        gameObject.SetActive(true);
    }
}