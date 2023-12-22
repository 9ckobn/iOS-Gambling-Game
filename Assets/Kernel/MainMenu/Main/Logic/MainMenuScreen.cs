using UnityEngine;

public class MainMenuScreen : UIScreen, IMenuItem
{
    [SerializeField] private UIScreen footerArea, headerArea;
    [SerializeField] private RulesScreen rulesScreen;

    public override void StartScreen()
    {
        SetupBasicElements();
    }

    private void SetupBasicElements()
    {
        footerArea.StartScreen();
        headerArea.StartScreen();
    }

    public void ShowRules()
    {
        rulesScreen.StartScreen();
        PlayerStats.SetFirstEnter();
    }
}