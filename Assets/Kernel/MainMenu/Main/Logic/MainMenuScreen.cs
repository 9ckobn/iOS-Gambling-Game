using UnityEngine;

public class MainMenuScreen : UIScreen, IMenuItem
{
    [SerializeField] private UIScreen footerArea, headerArea;
    [SerializeField] private RulesScreen rulesScreen;

    [SerializeField] private GameSelectorScreen gameSelectorScreen;

    public override void StartScreen()
    {
        SetupBasicElements();
    }

    private void SetupBasicElements()
    {
        footerArea.StartScreen();
        headerArea.StartScreen();

        gameSelectorScreen.StartScreen();
    }
}