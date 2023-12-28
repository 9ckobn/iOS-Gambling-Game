using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CurrentLvl")]
public class LvlSettings : ScriptableObject
{
    public List<Lvl> lvlList;
}



[Serializable]
public class Lvl
{
    public int index;
    public int stepsCount;

    public LvlScreen lvlPrefab;
}