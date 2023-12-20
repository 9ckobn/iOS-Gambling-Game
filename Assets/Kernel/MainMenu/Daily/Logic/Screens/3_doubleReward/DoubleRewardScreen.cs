using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleRewardScreen : BonusScreen
{
    private DoubleChestElement neededChest;
    [SerializeField] private DoubleChestElement[] chestsArray = new DoubleChestElement[4];

    private bool isRewardDoubled = false;

    public override void StartScreen()
    {
        int randomIndex = Random.Range(0, 3);

        chestsArray[randomIndex].trueChest = true;

        foreach(var item in chestsArray)
        {
            if(item.trueChest)
            {
                item.OnClick += SetupReward;
            }
            else
            {
                item.OnClick += DisableChests;
            }
        }
    }

    private void DisableChests()
    {
        foreach(var item in chestsArray)
        {
            item.SetInteractivity();
        }

        ParentScreen.OpenFinalScreen(isRewardDoubled);
    }

    private async void SetupReward()
    {
        isRewardDoubled = true;
        ParentScreen.currentReward *= 2;
        DisableChests();
    }
}
