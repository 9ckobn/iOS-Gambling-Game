using TMPro;
using UnityEngine;

public class NotificationButton : MainButton
{
    private DefaultNotification _mainScreen;

    public void SetupButton(DefaultNotification mainScreen)
    {
        _mainScreen = mainScreen;
    }

    public void SetupCloseScreen()
    {
        _mainScreen.SetupCloseScreen();
    }
}