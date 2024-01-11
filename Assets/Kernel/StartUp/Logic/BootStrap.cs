using Cysharp.Threading.Tasks;
using OneSignalSDK;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using Zenject;

public class BootStrap : MonoInstaller, IUnityAdsInitializationListener
{
    public int OnBoardSceneIndex;
    public int MainMenuSceneIndex;

    public const string gameId = "5509592";
    public bool testMode = false;

    public override void InstallBindings()
    {
        StartSceneLoading();
    }

    private async void StartSceneLoading()
    {
        AsyncOperation sceneTask;

        Application.targetFrameRate = 60;
        
        await SetupSignal();
        
        SetupAd();

        sceneTask = SceneManager.LoadSceneAsync(PlayerStats.IsFirstEnter ? OnBoardSceneIndex : MainMenuSceneIndex);

        gameObject.AddComponent<RequestStoreRate>();
    }

    private void SetupAd()
    {
        Advertisement.Initialize(gameId, false, this);
    }

    private async UniTask SetupSignal()
    {
        OneSignal.ConsentRequired = true;
        
        OneSignal.Initialize("f4f7b74c-411a-4039-bd77-ed07c4674cc9");
        
        OneSignal.User.PushSubscription.OptIn();
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
