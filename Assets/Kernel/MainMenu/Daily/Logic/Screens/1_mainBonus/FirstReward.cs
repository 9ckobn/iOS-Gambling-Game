using UnityEngine;
using UnityEngine.UI;

public class FirstReward : BonusScreenBase
{
    private int[] rewardsAmount = new int[10] { 50, 100, 200, 350, 400, 500, 670, 800, 1000, 1200 };
    [SerializeField] private PrizeElement[] prizeElement = new PrizeElement[3];

    public override void StartScreen()
    {
        foreach (var item in prizeElement)
        {
            item.OnClick += UnveilPrize;
        }
    }

    private void UnveilPrize()
    {
        ParentScreen.currentReward = rewardsAmount[Random.Range(0, 9)];
        ParentScreen.OpenReward();
    }
}
