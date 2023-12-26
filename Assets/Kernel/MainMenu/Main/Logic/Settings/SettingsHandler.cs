using System;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.UI;

public class SettingsHandler : UIScreen
{
    [SerializeField] private EmailSettings emailSettings;
    [SerializeField] private ReportScreen reportScreen;
    [SerializeField] private Sprite notifToggleEnable, notifToggleDisable;
    [SerializeField] private Button notification, privacy, terms, report, support, share, rate;
    [SerializeField] private string privacyUrl, termsUrl;

    [SerializeField] private Texture2D shareImage;
    private NativeShare nativeShareInstance;

    private const string notificationKey = "notifs";
    private bool notificationsEnabled
    {
        get => PlayerPrefs.GetInt(notificationKey, 1) == 1;
        set
        {
            if (value)
            {
                PlayerPrefs.SetInt(notificationKey, 1);
                notification.targetGraphic.GetComponent<Image>().sprite = notifToggleEnable;
            }
            else
            {
                PlayerPrefs.SetInt(notificationKey, 0);
                notification.targetGraphic.GetComponent<Image>().sprite = notifToggleDisable;
            }
        }
    }

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        SetupNotification();

        SetupSendEmail();

        SetupButtons();
    }

    private void SetupSendEmail()
    {
        reportScreen.onSend = emailSettings.SendEmail;

        report.onClick.AddListener(OpenReport);
    }

    private void OpenReport()
    {
        reportScreen.StartScreen();
    }

    private void SetupNotification()
    {
        //todo Add Notification Service here
        notification.targetGraphic.GetComponent<Image>().sprite = notificationsEnabled ? notifToggleEnable : notifToggleDisable;
    }

    private void SetupButtons()
    {
        notification.onClick.AddListener(SwitchNotifications);
        privacy.onClick.AddListener(() => Application.OpenURL(privacyUrl));
        terms.onClick.AddListener(() => Application.OpenURL(termsUrl));
        report.onClick.AddListener(() => reportScreen.StartScreen());
        share.onClick.AddListener(ShareApp);
        rate.onClick.AddListener(() => Device.RequestStoreReview());
    }

    private void ShareApp()
    {
        if (nativeShareInstance == null)
        {
            nativeShareInstance = new NativeShare().SetTitle("Title").SetText("SubTitle and url to game at appstore");
        }
        else
        {
            nativeShareInstance.Share();
        }
    }

    private void SwitchNotifications() => notificationsEnabled = !notificationsEnabled;
}

[Serializable]
public class EmailSettings
{
    public string mailToAddress;
    private string Subject = "Report from App";

    public void SendEmail(string body)
    {
        string emailUri = "mailto:" + mailToAddress + "?subject=" + Subject + "&body=" + body;

        Application.OpenURL(emailUri);
    }
}
