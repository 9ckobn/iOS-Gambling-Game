using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class LvlSelect : MainButton, IUnityAdsShowListener
{
    private const string placement = "Interstitial_iOS";

    [SerializeField] private TextMeshProUGUI lvlNumber;

    public int lvlIndex;

    private Action onAdsDone;

    public void SetupAd(Action onAds)
    {
        Advertisement.Show(placement, this);

        onAdsDone = onAds;
    }

    public override void ChangeText(string text)
    {
        Debug.Log($"{lvlIndex}{name}");
        base.ChangeText(text);
        lvlNumber.text = lvlIndex.ToString();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Ads fail {message}");
        onAdsDone?.Invoke();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"Ads complete");
        onAdsDone?.Invoke();
    }
}
