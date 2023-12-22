using System;
using System.Collections.Generic;
using UnityEngine;

public class TabSelector : MonoBehaviour
{

    /// <summary>
    /// Main collection with pair of tab button and attached screen
    /// </summary>
    [SerializeField] private TabScreenPair[] tabScreenPairs = new TabScreenPair[3];

    public void SetupTabs()
    {
        SetStartScreen();
        
        foreach (var item in tabScreenPairs)
        {
            item.tabButton.OnClick += () => OpenScreen(item);
        }
    }
    
    private void OpenScreen(TabScreenPair tabScreen)
    {
        ClearUI();
        tabScreen.screen.StartScreen();
    }

    private void ClearUI()
    {
        foreach (var item in tabScreenPairs)
        {
            item.screen.CloseScreen();
        }
    }   

    private void SetStartScreen()
    {
        tabScreenPairs[0].screen.StartScreen();
    }
}


[Serializable]
public struct TabScreenPair
{
    public TabBase tabButton;
    public UIScreen screen;
}
