using UnityEngine;

public class RulesScreen : UIScreen
{
    [SerializeField] private MainButton[] mainButtons = new MainButton[2];

    public override void StartScreen()
    {
        Debug.Log("start screen");

        gameObject.SetActive(true);

        foreach (var item in mainButtons) item.OnClick += () => CloseScreenWithAnimation();
    }
}