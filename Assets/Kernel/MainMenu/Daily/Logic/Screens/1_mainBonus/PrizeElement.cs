public class PrizeElement : ClickableElement
{
    public int rewardAmount = 0;

    public void Claim()
    {
        PlayerStats.MoneyCount += rewardAmount;
    }
}