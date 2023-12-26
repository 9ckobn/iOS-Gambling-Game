using TMPro;
using UnityEngine;

public class Header : UIScreen, IMenuItem
{
    [SerializeField] private TextMeshProUGUI moneyCuntText;

    public override void StartScreen()
    {
        gameObject.SetActive(true);
    }

    public void UpdateMoneyCount()
    {
        moneyCuntText.text = $"{PlayerStats.MoneyCount} <sprite=0>";
    }
}