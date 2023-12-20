using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class OnBoardingSettings : ScriptableObject
{
    public List<ScreenInfo> screenInfos;
}

[Serializable]
public class ScreenInfo
{
    public string h1, h2, h3;
    public Sprite coreImage;
}
