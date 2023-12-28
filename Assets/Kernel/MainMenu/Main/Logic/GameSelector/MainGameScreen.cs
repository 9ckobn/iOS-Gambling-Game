using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScreen : UIScreen
{
    public Lvl lvlSettings;
    public UIScreen screen;
    [SerializeField] private TextMeshProUGUI hpCounter;
    [SerializeField] private Button close, rules;

    LvlScreen currentLevel;

    public override void StartScreen()
    {
        close.onClick.RemoveAllListeners();
        rules.onClick.RemoveAllListeners();

        close.onClick.AddListener(CloseScreen);
        rules.onClick.AddListener(DefaultNotification.instance.SetupScreenForRules);

        gameObject.SetActive(true);

        currentLevel = Instantiate(lvlSettings.lvlPrefab, transform);
        currentLevel.transform.SetSiblingIndex(1);
        currentLevel.hpConuter = hpCounter;
        currentLevel.StartScreen();

        currentLevel.screen = screen;
    }

    void OnDisable()
    {
        currentLevel.CloseScreen();
    }
}