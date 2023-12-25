using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : UIScreen
{
    //[SerializeField] ShopElementObjectFull fullElementScreen;

    [SerializeField] DefaultNotification fullElementScreen;
    [SerializeField] private ShopItemsConfigurator itemsConfig;
    [SerializeField] private RectTransform scrollViewContent;

    private List<ShopElementObject> allElements;

    private bool alreadyCreated = false;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        if (alreadyCreated)
        {
            foreach (var item in allElements)
            {
                item.EnableElement();
            }
        }
        else
        {
            allElements = new List<ShopElementObject>();
            PrepareScrollView();
        }
    }

    public override void CloseScreen()
    {
        if(alreadyCreated)
            foreach (var item in allElements)
            {
                item.DisableElement();
            }

        gameObject.SetActive(false);
    }

    private void PrepareScrollView()
    {
        if (alreadyCreated)
            return;

        int id = 0;

        foreach (var item in itemsConfig.allItems)
        {
            item.setPurchaseKey(id++);

            var shopGameObject = Instantiate(itemsConfig.shopElementObject, transform.position, Quaternion.identity, scrollViewContent);

            allElements.Add(shopGameObject);

            shopGameObject.SetupMiniature(item);

            if (!item.isPurchased)
            {
                shopGameObject.OnClick += () => fullElementScreen.SetupScreenForShop(shopGameObject) ;
            }
        }

        alreadyCreated = true;
    }
}
