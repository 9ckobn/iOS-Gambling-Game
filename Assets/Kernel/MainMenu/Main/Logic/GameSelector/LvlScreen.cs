using System.Linq;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class LvlScreen : UIScreen
{
    [SerializeField] private RectTransform player;

    [SerializeField] private RectTransform scrollView;

    [SerializeField] private Row[] rows;

    public TextMeshProUGUI hpConuter;

    private int index;

    private int hp = 3;
    public UIScreen screen;

    public override void StartScreen()
    {
        hpConuter.text = hp.ToString();

        rows = GetComponentsInChildren<Row>();

        index = rows.Count() - 1;

        gameObject.SetActive(true);

        rows[index].EnableRow(() =>
        {
            rows[index].DisableRow();
            GoToNextStage();
        },
        () =>
        {
            hp--;

            if (hp <= 0)
                Lose();

            hpConuter.text = hp.ToString();
        });
    }

    public void GoToNextStage()
    {
        Debug.Log("goto");

        if (index <= 0)
        {
            Win();
            return;
        }

        var trueBlockposForPlayer = new Vector3();
        switch (rows[index].randomIndex)
        {
            case 0:
                trueBlockposForPlayer = new Vector3(-800, -1364, 0);
                break;
            case 1:
                trueBlockposForPlayer = new Vector3(0, -1364, 0);
                break;
            case 2:
                trueBlockposForPlayer = new Vector3(800, -1364, 0);
                break;
        }
        player.DOAnchorPos(trueBlockposForPlayer, 0.75f).SetEase(Ease.InOutQuint);

        index--;

        scrollView.DOAnchorPosY(scrollView.anchoredPosition.y - 750.03f - 99, 0.5f);

        rows[index].EnableRow(() =>
        {
            rows[index].DisableRow();
            GoToNextStage();
        },
        () =>
        {
            hp--;

            if (hp <= 0)
                Lose();

            hpConuter.text = hp.ToString();
        });
    }

    private void Win()
    {
        DefaultNotification.instance.SetupScreenForWin(screen);
    }

    private void Lose()
    {
        DefaultNotification.instance.SetupScreenForLose(screen);
    }
}