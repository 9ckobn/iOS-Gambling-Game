using System;
using UnityEngine;

public static class PlayerStats
{
    private const string MoneyCountKey = "Money";
    public static int MoneyCount { get => PlayerPrefs.GetInt(MoneyCountKey, 0); set => PlayerPrefs.SetInt(MoneyCountKey, value); }

    private const string LastLoginKey = "LastLogin";
    public static bool FirstLoginToday { get => FetchLastLogin();}

    private static bool FetchLastLogin()
    {
        DateTime now = DateTime.Now;

        string lastLoginString = PlayerPrefs.GetString(LastLoginKey);
        DateTime lastLogin = DateTime.MinValue;
        if (!string.IsNullOrEmpty(lastLoginString))
        {
            lastLogin = DateTime.Parse(lastLoginString);
        }

        PlayerPrefs.SetString(LastLoginKey, now.ToString());

        return lastLogin.Date < now.Date;
    }
}
