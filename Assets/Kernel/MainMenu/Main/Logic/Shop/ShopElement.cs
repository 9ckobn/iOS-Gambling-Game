using System;
using UnityEngine;

[Serializable]
public struct ShopElement
{
    public Sprite FullImage, MiniImage;
    public string Name;
    public int Price;
    private int purchasedKey;
    public bool isPurchased
    {
        get
        {
            return PlayerPrefs.GetInt($"status_{purchasedKey}", 0) == 1;
        }
    }
    public void SetPurchased() => PlayerPrefs.SetInt($"status_{purchasedKey}", 1);
    public bool IsEnoughMoney() => Price <= PlayerStats.MoneyCount;
    public void setPurchaseKey(int id) => purchasedKey = id;
}
