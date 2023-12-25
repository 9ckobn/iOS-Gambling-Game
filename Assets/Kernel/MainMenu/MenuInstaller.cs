using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private DailyBonusScreen dailyBonusScreen;

    [SerializeField] private MainMenuScreen mainMenuScreen;
    [SerializeField] private DefaultNotification notificationScreen;

    public override async void InstallBindings()
    {
        SetupMenu();
        await CheckDaily();
        await CheckRules();
    }

    private async UniTask CheckDaily()
    {
        if(PlayerStats.FirstLoginToday)
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