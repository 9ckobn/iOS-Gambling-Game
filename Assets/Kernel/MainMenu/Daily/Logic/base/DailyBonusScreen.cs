using UnityEngine;
using UnityEngine.UI;

public class DailyBonusScreen : MonoBehaviour
{
    public int currentReward = 0;

    [SerializeField] private BonusScreenBase firstScreen, rewardScreen, doubleRewardScreen;
    [SerializeField] private FinalScreen finalScreen;

    [SerializeField] private Image blur;

    public void StartDailyBonusProcess()
    {
        blur.enabled = true;
        firstScreen.SetupScreen(this);
    }

    public void OpenReward()
    {
        firstScreen.CloseScreen();
        rewardScreen.SetupScreen(this);
    }

    public void OpenDoubleReward()
    {
        rewardScreen.CloseScreen();
        doubleRewardScreen.SetupScreen(this);
    }

    public async void OpenFinalScreen(bool doubledReward)
    {
        await doubleRewardScreen.CloseScreenWithAnimation(3000);

        finalScreen.SetRewardWindow(doubledReward, currentReward);

        finalScreen.SetupScreen(this);
    }

    public async void CloseDailyBonus()
    {
        await finalScreen.CloseScreenWithAnimation();
        blur.enabled = false;
        enabled = false;
    }
}
