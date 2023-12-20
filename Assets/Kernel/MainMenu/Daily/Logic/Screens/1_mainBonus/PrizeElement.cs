public class PrizeElement : BonusElement
{
    public int rewardAmount = 0;

    public void Claim()
    {
        PlayerStats.MoneyCount += rewardAmount;
    }
}