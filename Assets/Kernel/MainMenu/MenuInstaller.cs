using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private DailyBonusScreen dailyBonusScreen;

    public override void InstallBindings()
    {
        CheckDaily();
    }

    private void CheckDaily()
    {
        if(PlayerStats.FirstLoginToday)
        {
            Container.Bind<DailyBonusScreen>().FromInstance(dailyBonusScreen).AsSingle();

            Container.Bind<DailyBonusHandler>().FromNewComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}