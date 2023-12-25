using TMPro;
using UnityEngine;

public class MainNotificationLayout : UIScreen
{
    [SerializeField] private TextMeshProUGUI h1, h2, h3;

    private const string h1_win = "You won!";
    private const string h2_win = "Congratulations! You cleared this level";
    private const string h3_win = "Close";

    private const string h1_lose = "You lost!";
    private const string h2_lose = "Try again and complete the mission!";
    private const string h3_lose = "Close";

    private const string h1_exit = "Exit?";
    private const string h2_exit = "Are you sure you want to leave? Progress will not be saved.";
    private const string h3_exit = "Close";

    private const string h1_rules = "RULES";
    private const string h2_rules = "The character has 3 lives. The levels will differ only in the number of steps.There will be 100 steps on the last level. The mines on each level will be saved in the same order.If you step on a mine, you start the level all over again.";
    private const string h3_rules = "Start";

    public void SetupButtonTextRef(TextMeshProUGUI tmproText)
    {
        h3 = tmproText;
    }

    public override void StartScreen()
    {
        gameObject.SetActive(true);
    }

    public void SetupText(NotificationTextType type)
    {
        switch (type)
        {
            case NotificationTextType.win:
                h1.text = h1_win;
                h2.text = h2_win;
                h3.text = h3_win;
                break;
            case NotificationTextType.lose:
                h1.text = h1_lose;
                h2.text = h2_lose;
                h3.text = h3_lose;
                break;
            case NotificationTextType.exit:
                h1.text = h1_exit;
                h2.text = h2_exit;
                h3.text = h3_exit;
                break;
            case NotificationTextType.rules:
                h1.text = h1_rules;
                h2.text = h2_rules;
                h3.text = h3_rules;
                break;
        }

        StartScreen();
    }
}

public enum NotificationTextType
{
    win,
    lose,
    exit,
    rules
}