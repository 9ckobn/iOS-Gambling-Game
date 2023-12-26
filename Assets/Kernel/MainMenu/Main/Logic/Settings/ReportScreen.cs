using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReportScreen : UIScreen
{
    [SerializeField] private Button sendButton, closeButton;
    [SerializeField] private TMP_InputField inputField;

    public UnityAction<string> onSend;

    public override void StartScreen()
    {
        sendButton.interactable = false;
        inputField.ActivateInputField();

        closeButton.onClick.AddListener(async () => await CloseScreenWithAnimation());

        inputField.onValueChanged.AddListener((string value) =>
        {
            if (!string.IsNullOrEmpty(value))
            {
                sendButton.interactable = true;
            }
        });

        inputField.onEndEdit.AddListener((string value) =>
        {
            sendButton.onClick.AddListener(() => onSend?.Invoke(value));
        });

        gameObject.SetActive(true);
    }

    void OnDisable()
    {
        inputField.text = "";
    }
}