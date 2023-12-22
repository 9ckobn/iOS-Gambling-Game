using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RewardScreen : BonusScreenBase
{
    [SerializeField] private TextMeshProUGUI rewardTextMesh;
    [SerializeField] private Image mainRewardImage;

    [SerializeField] private Button doubleReward;


    public override void StartScreen()
    {
        mainRewardImage.rectTransform.localScale = mainRewardImage.rectTransform.localScale * 2f;

        mainRewardImage.rectTransform.DOScale(1.3f, 0.5f).SetEase(Ease.OutBounce);

        rewardTextMesh.text = GetRewardText();

        doubleReward.onClick.AddListener(GoToDoubleReward);
    }

    public void GoToDoubleReward()
    {
        ParentScreen.OpenDoubleReward();
    }

    public string GetRewardText() => $"You won {ParentScreen.currentReward} <sprite=0>";
}
