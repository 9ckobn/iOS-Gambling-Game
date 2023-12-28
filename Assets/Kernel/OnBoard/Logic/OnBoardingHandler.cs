using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBoardingHandler : MonoBehaviour, IUnityAdsShowListener
{
    [SerializeField] private OnBoardingSettings settings;

    [SerializeField] private TextMeshProUGUI h1, h2, h3;
    [SerializeField] private Image baseImage;

    private int _index = 0;

    public Button nextButton;

    void OnEnable()
    {
        NextScreen();
        nextButton.onClick.AddListener(NextScreen);
    }

    public void NextScreen()
    {
        if (_index >= 3)
        {
            Advertisement.Show("Interstitial_iOS", this);

            return;
        }

        SetScreen(_index);
        _index++;
    }

    public void SetScreen(int index)
    {
        h1.text = settings.screenInfos[index].h1;
        h2.text = settings.screenInfos[index].h2;
        h3.text = settings.screenInfos[index].h3;

        baseImage.sprite = settings.screenInfos[index].coreImage;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Cannot play Ad now {message}");
        var sceneTask = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ad Started");
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ad complete");
        var sceneTask = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
