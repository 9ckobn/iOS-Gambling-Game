using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : BonusScreenBase
{
    [SerializeField] private Image targetWindow;
    [SerializeField] private Sprite doubledWindow, defaultWindow;

    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private Button claimReward;

    public override void StartScreen()
    {
        claimReward.onClick.AddListener(Claim);
    }

    public void Claim()
    {
        PlayerStats.MoneyCount += ParentScreen.currentReward;
        ParentScreen.CloseDailyBonus();
    }

    public void SetRewardWindow(bool isRewardDoubled, int currentReward)
    {
        mainText.text = isRewardDoubled ? "Congratulations! Your prize is doubled!" : $"You won {currentReward} <sprite=0>";
        targetWindow.sprite = isRewardDoubled ? doubledWindow : defaultWindow;
    }
}
