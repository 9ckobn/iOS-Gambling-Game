using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootStrap : MonoInstaller
{
    private const string firstStartKey = "first_enter";
    private const int firstStartValue = 1;

    public int OnBoardSceneIndex;
    public int MainMenuSceneIndex;

    public override void InstallBindings()
{
        StartSceneLoading();
    }

    private void StartSceneLoading()
    {
        AsyncOperation sceneTask;

        sceneTask = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt(firstStartKey) == 1 ? MainMenuSceneIndex : OnBoardSceneIndex);
    }

    public void ResetFirstEnter() => PlayerPrefs.SetInt(firstStartKey, 0);

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(firstStartKey, firstStartValue);
    }
}
