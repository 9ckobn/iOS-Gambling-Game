using OneSignalSDK;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using Zenject;

public class BootStrap : MonoInstaller, IUnityAdsInitializationListener
{
    public int OnBoardSceneIndex;
    public int MainMenuSceneIndex;

    public const string onSignalSdk = "f4f7b74c-411a-4039-bd77-ed07c4674cc9";

    public const string gameId = "5509592";
    public bool testMode = true;

    public override void InstallBindings()
    {
        StartSceneLoading();
    }

    private void StartSceneLoading()
    {
        AsyncOperation sceneTask;

        Application.targetFrameRate = 60;

        // SetupOneSignalSDK();

        SetupAd();

        sceneTask = SceneManager.LoadSceneAsync(PlayerStats.IsFirstEnter ? OnBoardSceneIndex : MainMenuSceneIndex);
    }

    private void SetupOneSignalSDK()
    {
        OneSignal.Initialize(onSignalSdk);
    }

    private void SetupAd()
    {
        Advertisement.Initialize(gameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads Inited");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Ads error {message}");
    }
}
