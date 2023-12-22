using UnityEngine;
using Zenject;

public class MainMenuHandler : MonoBehaviour
{
    private MainMenuScreen mainMenuScreen;

    [Inject]
    private void Construct(MainMenuScreen mms)
    {
        mainMenuScreen = mms;
    }
}