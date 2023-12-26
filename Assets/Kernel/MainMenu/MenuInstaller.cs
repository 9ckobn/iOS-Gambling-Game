using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private DailyBonusScreen dailyBonusScreen;
    [SerializeField] private MainMenuScreen mainMenuScreen;
    [SerializeField] private DefaultNotification notificationScreen;
    [SerializeField] private Header header;

    public override async void InstallBindings()
    {
        SetupPlayerStats();
        SetupHeader();
        SetupMenu();
        await CheckDaily();
        await CheckRules();
    }

    private async UniTask CheckDaily()
    {
        if (PlayerStats.FirstLoginToday)
        {
            Container.Bind<DailyBonusScreen>().FromInstance(dailyBonusScreen).AsSingle();

            Container.Bind<DailyBonusHandler>().FromNewComponentOn(gameObject).AsSingle().NonLazy();

            await UniTask.WaitUntil(() => dailyBonusScreen.enabled == false);
        }
    }

    private void SetupMenu()
    {
        Container.Bind<MainMenuScreen>().FromInstance(mainMenuScreen).AsSingle();
        Container.Bind<MainMenuHandler>().FromNewComponentOn(gameObject).AsSingle().NonLazy();

        mainMenuScreen.StartScreen();
    }

    private void SetupHeader()
    {
        header.UpdateMoneyCount();
        header.StartScreen();
    }

    private void SetupPlayerStats()
    {
        PlayerStats playerStats = new PlayerStats(header);
    }

    private async UniTask CheckRules()
    {
        if (PlayerStats.IsFirstEnter)
        {
            notificationScreen.SetupMainLayout();
            notificationScreen.SetupScreenForRules();
            PlayerStats.SetFirstEnter();
        }
    }
}