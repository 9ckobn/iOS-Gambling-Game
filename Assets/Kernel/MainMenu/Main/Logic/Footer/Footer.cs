using UnityEngine;

[RequireComponent(typeof(TabSelector))]
public class Footer : UIScreen, IMenuItem
{
    private TabSelector tabSelector;

    public override void StartScreen()
    {
        tabSelector = GetComponent<TabSelector>();

        tabSelector.SetupTabs();
    }
}