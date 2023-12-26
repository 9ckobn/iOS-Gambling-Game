using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefaultNotification : UIScreen
{
	[SerializeField] private NotificationButton closeButton, mainButton;
	[SerializeField] private ShopElementObjectFull shopScreenLayout;
	[SerializeField] private MainNotificationLayout mainNotificationLayout;
	[SerializeField] private Image blur;

	[SerializeField] private TextMeshProUGUI buttontext;
	[SerializeField] private Color defaultTextColor, greenTextColor;
	[SerializeField] private Sprite defaultSprite, positiveSprite, negativeSprite;

	[SerializeField] private int timeOutToClose = 1500;

	private bool shopScreenSetted = false;

	public void SetupScreenForShop(ShopElementObject element)
	{
		blur.enabled = true;

		mainNotificationLayout.gameObject.SetActive(false);

		shopScreenLayout.currentItem = element;

		SetupCloseScreen();

		if (element.currentElementSettings.IsEnoughMoney())
		{
			mainButton.ChangeSprite(positiveSprite);
			buttontext.text = "Buy";

			mainButton.OnClick = SetupFirstEnableForShop;

			shopScreenLayout.OnItemPurchased = CloseScreenWithTimeOut;

			shopScreenLayout.SetupScreen(true);
		}
		else
		{
			mainButton.ChangeSprite(negativeSprite);
			buttontext.text = "Close";
			shopScreenLayout.SetupScreen(false);
		}

		StartScreen();
	}

	private void SetupFirstEnableForShop()
	{
		mainButton.ChangeText("Purchased");
		shopScreenLayout.PurchaseItem();
		shopScreenSetted = true;
		mainButton.OnClick = null;
	}

	public void SetupScreenForRules()
	{
		shopScreenLayout.gameObject.SetActive(false);
		mainNotificationLayout.SetupText(NotificationTextType.rules);
		StartScreen();
	}

	public override void StartScreen()
	{
		closeButton.SetupButton(this);

		mainButton.SetupButton(this);
		gameObject.SetActive(true);
	}

	public void SetupMainLayout()
	{
		mainNotificationLayout.SetupButtonTextRef(buttontext);
		SetupCloseScreen();
		blur.enabled = true;
	}

	public void SetupCloseScreen()
	{
		closeButton.OnClick += CloseScreen;
		mainButton.OnClick += CloseScreen;
	}

	public async override void CloseScreen()
	{
		mainButton.OnClick -= SetupFirstEnableForShop;
		await CloseScreenWithAnimation();
		blur.enabled = false;
	}

	public async void CloseScreenWithTimeOut()
	{
		await CloseScreenWithAnimation(timeOutToClose);
		blur.enabled = false;
	}
}
