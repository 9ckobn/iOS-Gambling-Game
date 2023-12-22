using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootStrap : MonoInstaller
{
    public int OnBoardSceneIndex;
    public int MainMenuSceneIndex;

    public override void InstallBindings()
    {
        StartSceneLoading();
    }

    private void StartSceneLoading()
    {
        AsyncOperation sceneTask;

        sceneTask = SceneManager.LoadSceneAsync(PlayerStats.IsFirstEnter ? OnBoardSceneIndex : MainMenuSceneIndex);
    }
}
