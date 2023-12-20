using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DailyBonusHandler : MonoBehaviour
{
    private DailyBonusScreen dailyBonusScreen;

    [Inject]
    public void Construct(DailyBonusScreen dbs)
    {
        dailyBonusScreen = dbs;
        dailyBonusScreen.StartDailyBonusProcess();
    }
}
