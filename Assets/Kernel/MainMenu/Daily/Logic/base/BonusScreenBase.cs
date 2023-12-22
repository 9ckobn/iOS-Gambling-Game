public abstract class BonusScreenBase : UIScreen
{
    protected DailyBonusScreen ParentScreen;

    public void SetupScreen(DailyBonusScreen dbs)
    {
        ParentScreen = dbs;

        gameObject.SetActive(true);

        StartScreen();
    }
}