using UnityEngine;
using UnityEngine.UI;

public class GameSelectorScreen : UIScreen
{
    public LvlSettings lvlSettings;

    [SerializeField] private MainGameScreen mainGameScreen;

    [SerializeField] private LvlSelect[] alllevels;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        SetupLevels();
    }

    public void SetupLevels()
    {
        for (int i = 0; i < alllevels.Length; i++)
        {
            SetupButton(alllevels[i], lvlSettings.lvlList[i]);
        }
    }

    private void SetupButton(LvlSelect button, Lvl settings)
    {
        button.lvlIndex = settings.index;

        button.ChangeText(settings.stepsCount.ToString());

        button.OnClick += () =>
        {
            mainGameScreen.lvlSettings = settings;

            button.SetupAd(mainGameScreen.StartScreen);
        };
    }
}